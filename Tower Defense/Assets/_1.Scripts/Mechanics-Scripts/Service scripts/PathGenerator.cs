using UnityEngine;
using System.Collections.Generic;


public class PathGenerator: Singleton<PathGenerator>
{
    [SerializeField] private Transform WaypointsParent;

    private Waypoint[] waypoints;

    private void Awake()
    {
        waypoints = WaypointsParent.GetComponentsInChildren<Waypoint>();
    }

    public Queue<Transform> GeneratePath()
    {
        if (waypoints.Length <= 0) return null;

        Waypoint point = waypoints[0];

        Queue<Transform> path = new Queue<Transform>();
        path.Enqueue(point.transform);

        int waypointChildPoints = point.childCount;

        while(waypointChildPoints > 0)
        {
            if (waypointChildPoints == 1)
                point = point.GetChild(0);
            else
            {
                int randomChild = Random.Range(0, waypointChildPoints);
                point = point.GetChild(randomChild);
            }

            path.Enqueue(point.transform);
            waypointChildPoints = point.childCount;
        }

        return path;
    }
}