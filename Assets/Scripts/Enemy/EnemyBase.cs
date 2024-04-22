using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public EnemyType enemyType;
    public Ease easeLinear = Ease.Linear; // Ease type for the movement (optional)
    
    
    public int scoreValue; //the score of this enemy
    // public Transform groundCheck; // Optional transform for ground detection
    public float waitTimeAtWaypoint = 1f; // Time to wait at each waypoint (seconds)

    //Protected
    protected float health; 
    protected float movementSpeed;
    [SerializeField] protected GameObject waypoints; // List of waypoints to follow
    [SerializeField] protected int currentWaypointIndex = 0; // Index of the current waypoint
    [SerializeField] protected float speed = 5f;
    
    //Private
    

    public virtual void Start()
    {
        
    }

    public abstract void TakeDamage(float amount);
    

    public IEnumerator MoveToNextWayPoint()
    {
        while (true)
        {
            if (currentWaypointIndex >= waypoints.transform.childCount)
                currentWaypointIndex = 0;

            Vector2 startPoint = transform.position;
            Vector2 endPoint = waypoints.transform.GetChild(currentWaypointIndex).position;
        
            transform.DOMove(endPoint, Vector2.Distance(endPoint, startPoint)/speed).SetEase(easeLinear);
            currentWaypointIndex++;
        
            yield return new WaitForSeconds(waitTimeAtWaypoint); 
        }
        
        // StartCoroutine(MoveToNextWayPoint());
    
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //A force push player up above a little bit 
            Debug.Log("Hit the player");
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
