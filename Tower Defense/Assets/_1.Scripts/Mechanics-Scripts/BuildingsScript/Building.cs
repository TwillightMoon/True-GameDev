using UnityEngine;
using ConfigClasses.BuildingConfig;
using Buildings.TowerStates;
using UnityEngine.Events;
using System.Collections.Generic;

/** Пространство имен классов, что относятся к постройкам.
 *  К этому пространству имён относятся классы, наследующиеся от Building, а также модули, дополняющие поведение построек.
 */
namespace Buildings
{
    /** Родительский класс для всех построек.
    * Класс определяет базовый набор полей и методов, которые являются общими для всех построек.
    */
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public abstract class Building : 
        MonoBehaviour, IStateChange, IInteractable, IModuleHub
    {
        //События
        [HideInInspector] public UnityEvent onSelect = new UnityEvent();
        [HideInInspector] public UnityEvent onDeselect = new UnityEvent();

        [Header("Модули")]
        private LinkedList<IModule> modules = new LinkedList<IModule>();

        [Header("Компоненты")]
        protected Rigidbody2D _rigidbody2D /**< Rigidbody2D variable. Компонент, отвечающий за физическую обработку. */;
        protected SpriteRenderer _spriteRenderer /**< SpriteRenderer variable. Компонент, отвечающий за отображение графики объекта. */;

        [Header("Характеристика постройки")]
        [SerializeField] protected BuildingsConfig _buildingCharacteristic /**< BuildingsConfig variable. Компонент, хранящий основыне хар-ки постройки. */;
        [SerializeField] protected int m_id; 

        [Header("Характеристика постройки на каждом уровне")]
        private int _currentLevelIndex = 0 /**< integer variable. Индекс текущего уровня постройки */;
        [SerializeField] protected BuildingsConfig[] _towerLevels /**< integer[] variable. Массив уровней построки. */;

        [Header("Состояния постройки")]
        [SerializeField] protected TowerState[] towerStates; /**< TowerState[] variable. Массив состояний построки. */
        protected TowerState currentState /**< TowerState variable. Текущее состояние */;

        [Header("Флаги")]
        private bool _isSelect = false;

        public BuildingsConfig buildingsConfig => _buildingCharacteristic;

        public bool isSelect { get => this._isSelect; }


        /**
        * Метод инициализации объекта. Вызывается из конкретной постройки в методе Start().
        */
        protected void Init()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();

            _rigidbody2D.bodyType = RigidbodyType2D.Static;

            SortLevels();
            SetNewCharacteristics();
        }

        /**
         * Метод получения возможного следующего уровня постройки.
         * @return Следующий доступный уровень или null.
         * @see SetNextLevel()
        */
        public BuildingsConfig GetNextLevel()
        {
            int newLevel = _currentLevelIndex + 1;
            if (newLevel < _towerLevels.Length)
                return _towerLevels[newLevel];

            return null;
        }
        /**
         * Метод улучшения характеристик башни, посредством увеличения её уровня.
         * @see SetNewCharacteristics()
        */
        public void SetNextLevel()
        {
            int newLevel = Mathf.Clamp(_currentLevelIndex + 1, 0, _towerLevels.Length - 1);

            if ((newLevel > _currentLevelIndex) && _towerLevels[_currentLevelIndex])
            {
                _currentLevelIndex = newLevel;
                _buildingCharacteristic = _towerLevels[_currentLevelIndex];
                Debug.Log(string.Format("Set new Level: {0}", _towerLevels[_currentLevelIndex]));
                SetNewCharacteristics();
            }
        }
        /**
         * Метод, обновляющий характеристики постройки. Cледует после SetNewLevel().
         * @see SetNewLevel()
        */
        private void SetNewCharacteristics()
        {
            if (_spriteRenderer)
                _spriteRenderer.sprite = _buildingCharacteristic.towerSprite;
            else
                Debug.LogError("SpriteRenderer не установлен!");

            foreach(IModule item in modules)
            {
                item.SetSpecifications(buildingsConfig);
            }
        }


        /** Реализация контракта IStateChange.
         * Метод смены текущего состояния.
        */
        public void ChangeState<T>() where T : State
        {
            TowerState newState = FindState<T>();
            if (newState)
            {
                if (currentState) currentState.StateStop();

                currentState = newState;
                currentState.StateStart();
            }

            Debug.Log($"new state {currentState} is set.");
        }


        private void SortLevels()
        {
            for (int i = 1; i < _towerLevels.Length; i++)
            {
                BuildingsConfig cacheConfig = _towerLevels[i];

                int j = i - 1;
                for (; j >= 0 && _towerLevels[j].towerLevel > cacheConfig.towerLevel; j--)
                    _towerLevels[j + 1] = _towerLevels[j];

                _towerLevels[j + 1] = cacheConfig;
            }

            Debug.Log("Levels was sorted");
        }

        private TowerState FindState<T>() where T : State
        {
            TowerState findResult = null;

            for (int i = 0; i < towerStates.Length; i++)
                if (towerStates[i] is T)
                    findResult = towerStates[i];

            return findResult;
        }

        /** Реализация контракта IInteractable.
         * Метод, выполняющийся при выделении постойки игроком.
        */
        public void OnSelected()
        {
            _isSelect = true;
            onSelect.Invoke();
        }
        /** Реализация контракта IInteractable.
        * Метод, выполняющийся при отмене выделения постойки игроком.
        */
        public void OnDeselected()
        {
            _isSelect = false;
            onDeselect.Invoke();
        }

        public void AddModule(IModule module)
        {
            modules.AddLast(module);
        }

        public void RemoveModule(IModule module)
        {
            modules.Remove(module);
        }
    }
}

