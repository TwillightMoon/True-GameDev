using ModuleClass;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public abstract class Entity : MonoBehaviour, IStateChange, IInteractable, IModuleHub
{
    //События
    [HideInInspector] public UnityEvent onSelect = new UnityEvent();
    [HideInInspector] public UnityEvent onDeselect = new UnityEvent();

    [Header("Компоненты")]
    protected Rigidbody2D _rigidbody2D /**< Rigidbody2D variable. Компонент, отвечающий за физическую обработку. */;
    protected SpriteRenderer _spriteRenderer /**< SpriteRenderer variable. Компонент, отвечающий за отображение графики объекта. */;

    [Header("Модули")]
    protected LinkedList<Module> modules = new LinkedList<Module>();

    [Header("Флаги")]
    private bool _isSelect = false;

    public bool isSelect { get => this._isSelect; }

    /**
    * Метод инициализации объекта. Вызывается из конкретной постройки в методе Start().
    */
    protected void Awake()
    {
        Debug.Log("Инициализация");
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public Rigidbody2D Rigidbody2D => _rigidbody2D;

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

    public abstract void ChangeState<T>() where T : State;
}
