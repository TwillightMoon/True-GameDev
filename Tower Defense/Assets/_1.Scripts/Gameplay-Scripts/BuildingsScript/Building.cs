using Buildings.TowerStates;
using ConfigClasses.ConfigBuildings;
using ModuleClass;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    public class Building :
        MonoBehaviour, IStateChange, IInteractable, IModuleHub
    {
        //События
        [HideInInspector] public UnityEvent onSelect = new UnityEvent();
        [HideInInspector] public UnityEvent onDeselect = new UnityEvent();

        [Header("Компоненты")]
        protected Rigidbody2D _rigidbody2D /**< Rigidbody2D variable. Компонент, отвечающий за физическую обработку. */;
        protected SpriteRenderer _spriteRenderer /**< SpriteRenderer variable. Компонент, отвечающий за отображение графики объекта. */;

        [Header("Модули")]
        private LinkedList<Module> modules = new LinkedList<Module>();

        [Header("Характеристика постройки")]
        protected TowerConfig _buildingCharacteristic /**< BuildingsConfig variable. Компонент, хранящий основыне хар-ки постройки. */;

        [Header("Состояния постройки")]
        [SerializeField] protected TowerState[] towerStates; /**< TowerState[] variable. Массив состояний построки. */
        protected TowerState currentState /**< TowerState variable. Текущее состояние */;

        [Header("Флаги")]
        private bool _isSelect = false;


        public TowerConfig buildingsConfig => _buildingCharacteristic;

        public bool isSelect { get => this._isSelect; }

        /**
        * Метод инициализации объекта. Вызывается из конкретной постройки в методе Start().
        */
        protected void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();

            _rigidbody2D.bodyType = RigidbodyType2D.Static;

            if (towerStates.Length != 0)
            {
                for (int i = 0; i < towerStates.Length; i++)
                    towerStates[i].Init(this);
            }

            ChangeState<TowerChill>();
        }

        private void Update()
        {
            currentState.UpdateRun();
        }


        /**
         * Метод, обновляющий характеристики постройки. Cледует после SetNewLevel().
         * @see SetNewLevel()
        */
        public void SetNewCharacteristics(BuildingConfig buildingsConfig)
        {
            this._buildingCharacteristic = ClassConverter<TowerConfig>.Convert(buildingsConfig);

            if (_spriteRenderer)
                _spriteRenderer.sprite = _buildingCharacteristic.towerSprite;
            else
                Debug.LogError("SpriteRenderer не установлен!");

            foreach (Module item in modules)
            {
                item.UpdateData(buildingsConfig);
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

        public void AddModule(Module module)
        {
            _ = modules.AddLast(module);
        }

        public void RemoveModule(Module module)
        {
            _ = modules.Remove(module);
        }
    }   
}