using UnityEngine;

[System.Serializable]
public class Path : MonoBehaviour
{
    public Transform[] waypoints;

    public Transform GetWaypoint(int index)
    {
        return waypoints[index];
    }

    public int GetPathLength()
    {
        return waypoints.Length;
    }
}
