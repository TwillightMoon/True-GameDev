using ConfigClasses.UnitConfigs;

using DebugScripts.GizmosDebug;

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

        private Queue<Transform> _pathPoints;

        public UnitConfig unitCharacteristics => _unitCharacteristics;
        public Queue<Transform> pathPoints => _pathPoints;

        private new void Awake()
        {
            base.Awake();
            for(int i = 0; i < unitStates.Length; i++)
            {
                unitStates[i].Init(this);
            }

            _pathPoints = new Queue<Transform>();
        }
        private void Start()
        {
            _pathPoints = PathGenerator.instance.GeneratePath();
            ChangeState<UnitWalk>();
        }

        private void FixedUpdate()
        {
            if (currentState)
                currentState.FixedRun();
        }

        public void MoveTo(Transform targetTransform)
        {
            _pathPoints.Enqueue(targetTransform);
            if (currentState is UnitChill)
                ChangeState<UnitWalk>();
        }

        public void MoveTo(Queue<Transform> targetTransforms)
        {
            _pathPoints = targetTransforms;

            if (currentState is UnitChill)
                ChangeState<UnitWalk>();
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


        private void OnDrawGizmosSelected()
        {
            if (_pathPoints == null || _pathPoints.Count <= 0) return;
            Transform[] path = pathPoints.ToArray();

            for (int i = 0; i < path.Length - 1; i++)
                GizmosOnPlaying.DrawLine(path[i].position, path[i + 1].position, Color.red);
        }
    }

    
}