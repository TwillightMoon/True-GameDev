using UnityEngine;

public class DefensivePosition : MonoBehaviour
{
    [SerializeField] private OrientationEnum _blockOrientation = OrientationEnum.Up;
    private Buildings building;

    public Buildings GetBuilding() => building;
    public bool isOccupied => building != null;

    public void SetBuilding(Buildings buildingPrefab, Transform parent)
    {
        if (building != null)
        {
            Destroy(building.gameObject);
        }

        Quaternion rotation = Quaternion.Euler(Orientation.GetVectorRotation(_blockOrientation));
        building = Instantiate(buildingPrefab, transform.position, rotation, parent);
    }

    public void OnSelected()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        UIEvents.SendSelectedBlock(this);

    }
    public void OnUnSelected()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
