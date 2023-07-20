using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    private Path path;
    private int wavePointIndex = 0;

    public void SetPath(Path newPath)
    {
        path = newPath;
    }
    void Update()
    {
        Vector3 dir = path.GetWaypoint(wavePointIndex).position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, path.GetWaypoint(wavePointIndex).position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }
    void GetNextWaypoint()
    {
        if(wavePointIndex>= path.GetPathLength() - 1)
        {
            Destroy(gameObject);
        }
        wavePointIndex++;
    }
}
