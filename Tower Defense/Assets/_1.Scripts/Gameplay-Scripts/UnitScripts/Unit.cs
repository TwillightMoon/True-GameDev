using ConfigClasses.UnitConfigs;
using System.Collections.Generic;
using Units.UnitStates;
using UnityEngine;

/**Пространство имён, содержащее классы реализации игровых Юнитов */
namespace Units
{

    /** Абстрактный класс, определяющий базовые методы для всех юнитов */
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public abstract class Unit : Entity
    {

        [Header("Характеристика юнита")]
        [SerializeField] protected UnitConfig _unitCharacteristics /**< UnitConfig variable. Компонент, хранящий основыне хар-ки постройки. */;

        [Header("Состояния юнита")]
        [SerializeField] protected UnitState[] unitStates; /**< UnitState[] variable. Массив состояний построки. */
        protected UnitState currentState /**< UnitState variable. Текущее состояние */;

        private Queue<Vector2> _pathPoints;
        public Transform[] points;

        public UnitConfig unitCharacteristics => _unitCharacteristics;
        public Queue<Vector2> pathPoints => _pathPoints;

        private new void Awake()
        {
            base.Awake();
            for(int i = 0; i < unitStates.Length; i++)
            {
                unitStates[i].Init(this);
            }
        }
        private void Start()
        {
            _pathPoints = new Queue<Vector2>();
            for(int i = 0; i < points.Length; i++) 
            {
                _pathPoints.Enqueue(points[i].position);
            }

            ChangeState<UnitWalk>();
        }

        private void FixedUpdate()
        {
            if (currentState)
                currentState.FixedRun();
        }

        public void MoveTo(Vector2 movementVector)
        {
            _pathPoints.Enqueue(movementVector);
        }

        /** Реализация контракта IStateChange.
         * Метод смены текущего состояния.
        */
        public override void ChangeState<T>()
        {
            UnitState newState = FindState<T>();
            if (newState)
            {
                if (currentState) currentState.StateStop();

                currentState = newState;
                currentState.StateStart();
            }

            Debug.Log($"new state {currentState} is set.");
        }

        private UnitState FindState<T>() where T : State
        {
            UnitState findResult = null;

            for (int i = 0; i < unitStates.Length; i++)
                if (unitStates[i] is T)
                    findResult = unitStates[i];

            return findResult;
        }
    }
}