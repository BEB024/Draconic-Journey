using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    [SerializeField] WaveConfigSO waveConfig;
    Transform[] waypoints;
    int waypointIndex = 0;

    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waveConfig.GetStartingWaypoint().position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath() // This method moves the object along the waypoints defined in the waveConfig
    {
        if (waypointIndex < waypoints.Length)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float movementThisFrame = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame); // Move the object towards the target waypoint
            if (transform.position == targetPosition) // Check if the object has reached the target waypoint
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject); // Destroy the object when it has reached the last waypoint
        }
    }
}
