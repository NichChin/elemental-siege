using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float moveSpeed = 2f;
    private int currentWaypointIndex = 0;
    private Enemy enemy;
    void Start()
    {
        // make sure enemy starts at first waypoint
        if (waypoints.Length > 0) {
            transform.position = waypoints[0].position;
        }
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        if (waypoints.Length == 0 || enemy == null || enemy.HasReachedEnd) return;

        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = targetWaypoint.position - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);

        // check if close to next waypoint
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex++;

            // check if enemy is at last waypoint
            if (currentWaypointIndex >= waypoints.Length)
            {
                Debug.Log("im going to kill u");
                enemy.ReachEnd();
            }
        }


        
        
    }
}
