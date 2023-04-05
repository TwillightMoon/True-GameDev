using UnityEngine;
using GlobalUIEvents;

[RequireComponent(typeof(BoxCollider2D))]
public class TacticalPoint : MonoBehaviour
{
    [Header("Визуальные свойства")]
    [Tooltip("Цвета блока при выделении")]
    [SerializeField] private Color _selectedColor;

    // Компоненты
    private SpriteRenderer[] _childsSpriteRenderers;
    private BoxCollider2D _boxCollider2D;

    // Поля класса
    private Buildings _building;

    // Геттеры и Сеттеры
    public Buildings GetBuilding() => _building;
    public bool isOccupied => _building != null;

    public void SetBuilding(Buildings buildingPrefab, Transform parent)
    {
        if (_building != null)
            Destroy(_building.gameObject);

        _building = Instantiate(buildingPrefab, (Vector2)transform.position + _boxCollider2D.offset, Quaternion.identity, parent);

        OnDeselected();
    }
    public void DescructBuilding()
    {
        if (_building)
            Destroy(_building.gameObject);
    }

    public void OnSelected()
    {
        if (!_building)
            UIEvents.SendSelectedEmptyBlock(this);
        else
            UIEvents.SendSelectedOccupiedBlock(this);

        ChangeColor(_selectedColor);
    }
    public void OnDeselected()
    {
        UIEvents.SendDeselectBlock();

        ChangeColor(Color.white);
    }


    private void Start()
    {
        _childsSpriteRenderers = transform.GetComponentsInChildren<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void ChangeColor(Color newColor)
    {
        foreach (SpriteRenderer childSpriteRenderer in _childsSpriteRenderers)
            childSpriteRenderer.color = newColor;
    }
}
