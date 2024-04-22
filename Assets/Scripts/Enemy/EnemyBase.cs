using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public EnemyType enemyType;
    
    
    public int scoreValue;
    public Transform groundCheck; // Optional transform for ground detection
    public float waitTimeAtWaypoint = 1.0f; // Time to wait at each waypoint (seconds)

    protected List<Transform> waypoints; // List of waypoints to follow
    protected int currentWaypointIndex = 0; // Index of the current waypoint
    
    //Private
    private float health;
    private float movementSpeed;

    public virtual void Start()
    {
        waypoints = new List<Transform>(); // Initialize waypoints list
    }

    public abstract void TakeDamage(float amount);

    public virtual void Move()
    {
        if (waypoints.Count == 0) // No waypoints defined
        {
            return;
        }

        // Move towards current waypoint
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, movementSpeed * Time.deltaTime);

        // Check if reached the waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) <= 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count; // Loop to next waypoint
            StartCoroutine(WaitAtWaypoint()); // Start coroutine for waiting
        }
    }

    IEnumerator WaitAtWaypoint()
    {
        yield return new WaitForSeconds(waitTimeAtWaypoint);  // Wait for specified time
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
        }
    }
}

public enum EnemyType
{
    Snail,
    Mushroom,
    Crab,
    Cannon,
    Fish,
    Bee,
    Seafish,
    Hedgehog,
    Eagle
}
