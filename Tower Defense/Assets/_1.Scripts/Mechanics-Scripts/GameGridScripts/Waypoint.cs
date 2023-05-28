using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Color _gizmosColor;
    [SerializeField] private Waypoint _parent;
    [SerializeField] private Waypoint[] _childrends;

    public Waypoint GetChild(int index)
    {
        if (index < 0 || index >= _childrends.Length)
            return null;

        return _childrends[index];
    }
    public int childCount => _childrends.Length;
}
