using DebugScripts.GizmosDebug;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Waypoint[] _childrends;

    public Waypoint GetChild(int index)
    {
        if (index < 0 || index >= _childrends.Length)
            return null;

        return _childrends[index];
    }
    public int childCount => _childrends.Length;

    private void OnDrawGizmos()
    {
        if (_childrends == null || childCount <= 0) return;
        Gizmos.color = Color.blue;
        for (int i = 0; i < childCount; i++)
            Gizmos.DrawLine(transform.position, _childrends[i].transform.position);
    }   
}