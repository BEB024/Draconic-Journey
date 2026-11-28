using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "New WaveConfig")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] Transform pathPrefab;
    [SerializeField] float enemyMoveSpeed = 5f;

    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0); // Get the first child of the pathPrefab, which represents the starting waypoint of the path.
    }

    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed; // Return the enemy move speed value.
    }

    public Transform[] GetWaypoints() // Get all the waypoints of the pathPrefab as an array of Transform objects.
    {
        Transform[] waypoints = new Transform[pathPrefab.childCount];

        for (int i = 0; i < pathPrefab.childCount; i++)
        {
            waypoints[i] = pathPrefab.GetChild(i);
        }

        return waypoints;
    }
}