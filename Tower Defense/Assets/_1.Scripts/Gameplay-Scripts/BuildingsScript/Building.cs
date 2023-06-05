using Buildings.TowerStates;
using ConfigClasses.ConfigBuildings;
using ModuleClass;
using UnityEngine;

/** Пространство имен классов, что относятся к постройкам.
 *  К этому пространству имён относятся классы, наследующиеся от Building, а также модули, дополняющие поведение построек.
 */
namespace Buildings
{
    /** Родительский класс для всех построек.
    * Класс определяет базовый набор полей и методов, которые являются общими для всех построек.
    */

    public class Building : Entity
    {
        [Header("Характеристика постройки")]
        protected BuildingConfig _buildingCharacteristic /**< BuildingsConfig variable. Компонент, хранящий основыне хар-ки постройки. */;

        [Header("Состояния постройки")]
        [SerializeField] protected TowerState[] towerStates; /**< TowerState[] variable. Массив состояний построки. */
        protected TowerState currentState /**< TowerState variable. Текущее состояние */;

        public BuildingConfig buildingsConfig => _buildingCharacteristic;

        private new void Awake()
        {
            base.Awake();

            _rigidbody2D.bodyType = RigidbodyType2D.Static;
        }

        private void Start()
        {
            foreach(TowerState i in towerStates)
            {
                i.Init(this);
            }
            ChangeState<TowerChill>();
        }

        private void Update()
        {
            if (currentState)
                currentState.UpdateRun();
        }

        /**
         * Метод, обновляющий характеристики постройки. Cледует после SetNewLevel().
         * @see SetNewLevel()
        */
        public void SetNewCharacteristics(BuildingConfig buildingsConfig)
        {
            _buildingCharacteristic = buildingsConfig;

            if (_spriteRenderer)
                _spriteRenderer.sprite = _buildingCharacteristic.sprite;
            else
                Debug.LogError("SpriteRenderer не установлен!");

            foreach (Module item in modules)
            {
                item.UpdateData(buildingsConfig);
            }
        }

        public void UpdateCharacteristics()
        {
            if (_spriteRenderer)
                _spriteRenderer.sprite = _buildingCharacteristic.sprite;
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
        public override void ChangeState<T>()
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

        
    }
}