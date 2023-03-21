using UnityEngine;

public enum Orientation
{
    Left,
    Right,
    Up,
    Down
}

public class BlockForBuildings : MonoBehaviour
{
    [SerializeField] private Orientation orientation = Orientation.Up;
    private Buildings building;

    public Buildings GetBuilding() => building;
    public void SetBuilding(Buildings buildingPrefab, Transform parent)
    {
        if (building == null)
        {
            building = Instantiate(buildingPrefab, transform.position, Quaternion.Euler(GetVectorOrientation(orientation)), parent);
        }
    }


    private Vector3 GetVectorOrientation(Orientation orientation)
    {
        switch (orientation)
        {
            case Orientation.Left:
                return Vector3.forward * 90;
            case Orientation.Right:
                return Vector3.forward * -90;
            case Orientation.Up:
                return Vector3.zero;
            case Orientation.Down:
                return Vector3.forward * -180;
            default:
                return Vector3.zero;
        }
    }
}
