using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DefensivePosition : MonoBehaviour
{
    [SerializeField] private Color _selectedColor;
    [SerializeField] private bool _isSelected;

    [SerializeField] private OrientationEnum _blockOrientation = OrientationEnum.Up;
    private Buildings building;

    private SpriteRenderer[] _childsSpriteRenderers;
    private BoxCollider2D _boxCollider2D;

    public Buildings GetBuilding() => building;
    public bool isOccupied => building != null;

    public void SetBuilding(Buildings buildingPrefab, Transform parent)
    {
        if (building != null)
        {
            Destroy(building.gameObject);
        }

        Quaternion rotation = Quaternion.Euler(Orientation.GetVectorRotation(_blockOrientation));
        building = Instantiate(buildingPrefab, (Vector2)transform.position + _boxCollider2D.offset, rotation, parent);

        OnDeselected();
    }

    public void OnSelected()
    {
        if (!building)
            UIEvents.SendSelectedEmptyBlock(this);
        else
            UIEvents.SendSelectedOccupiedBlock(this);

        _isSelected = true;
        ChangeColor();
    }
    public void OnDeselected()
    {
        UIEvents.SendDeselectBlock();

        _isSelected = false;
        ChangeColor();
    }


    private void Start()
    {
        _childsSpriteRenderers = transform.GetComponentsInChildren<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void ChangeColor()
    {
        Color currentColor = _isSelected ? _selectedColor : Color.white;
        foreach (SpriteRenderer childSpriteRenderer in _childsSpriteRenderers)
        {
            childSpriteRenderer.color = currentColor;
        }
    }
}
