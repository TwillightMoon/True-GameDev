using System.Collections.Generic;

using ConfigClasses;
using ConfigClasses.UnitConfigs;

using ModuleClass;

using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

/**Пространство имён, содержащее классы реализации игровых Юнитов */
namespace Units
{

    /** Абстрактный класс, определяющий базовые методы для всех юнитов */
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public abstract class Unit : MonoBehaviour, IModuleHub, IInteractable, IStateChange
    {
        //События
        [HideInInspector] public UnityEvent onSelect = new UnityEvent();
        [HideInInspector] public UnityEvent onDeselect = new UnityEvent();

        [Header("Компоненты")]
        protected Rigidbody2D _rigidbody2D /**< Rigidbody2D variable. Компонент, отвечающий за физическую обработку. */;
        protected SpriteRenderer _spriteRenderer /**< SpriteRenderer variable. Компонент, отвечающий за отображение графики объекта. */;

        [Header("Модули")]
        private LinkedList<Module> modules = new LinkedList<Module>();

        [Header("Характеристика юнита")]
        [SerializeField] protected UnitConfig _unitCharacteristics /**< UnitConfig variable. Компонент, хранящий основыне хар-ки постройки. */;

        [Header("Состояния юнита")]
        [SerializeField] protected State[] unitStates; /**< TowerState[] variable. Массив состояний построки. */
        protected State currentState /**< TowerState variable. Текущее состояние */;

        [Header("Флаги")]
        private bool _isSelect = false;


        public UnitConfig unitCharacteristics => _unitCharacteristics;

        public bool isSelect { get => this._isSelect; }

        /**
        * Метод инициализации объекта. Вызывается из конкретной постройки в методе Start().
        */
        protected void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();

            _rigidbody2D.bodyType = RigidbodyType2D.Static;

            if (unitStates.Length != 0)
            {
            }
        }

        private void Update()
        {
            if (currentState)
                currentState.UpdateRun();
        }

        public void MoveTo(Vector2 movementVector)
        {

        }

        /** Реализация контракта IStateChange.
         * Метод смены текущего состояния.
        */
        public void ChangeState<T>() where T : State
        {
            State newState = FindState<T>();
            if (newState)
            {
                if (currentState) currentState.StateStop();

                currentState = newState;
                currentState.StateStart();
            }

            Debug.Log($"new state {currentState} is set.");
        }

        private State FindState<T>() where T : State
        {
            State findResult = null;

            for (int i = 0; i < unitStates.Length; i++)
                if (unitStates[i] is T)
                    findResult = unitStates[i];

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
