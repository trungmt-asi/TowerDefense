using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public float reachThreshold = 0.4f;

    private Transform target;
    private int waypointIndex = 0;

    void Start()
    {
        target = Waypoints.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(target.position, transform.position) <= reachThreshold)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if(waypointIndex >= Waypoints.points.Length - 1) {
            Destroy(gameObject);
            return;
        } 

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }
}
