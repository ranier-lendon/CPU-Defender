using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float health = 100f;

    private Transform currentWaypoint;
    private int currentWaypointIndex = 0;
    private Transform targetWaypoint;


    [SerializeField] private GameObject waypoints;
    private Rigidbody rb;

    void Start()
    {
        // Get the rigidbody component
        rb = GetComponent<Rigidbody>();

        // Find the waypoints object
        waypoints = GameObject.Find("Waypoints");

        // Set initial waypoints
        currentWaypoint = waypoints.transform.GetChild(currentWaypointIndex);
        targetWaypoint = waypoints.transform.GetChild(currentWaypointIndex + 1);
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + FindPath() * Time.fixedDeltaTime);

        // Checks if the enemy has reached the target waypoint
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.2f)
        {
            // Sets the target waypoint to current waypoint
            currentWaypoint = targetWaypoint;
            // Increments the current waypoint index
            currentWaypointIndex++;
            // Sets the target waypoint to the next waypoint
            targetWaypoint = waypoints.transform.GetChild(currentWaypointIndex + 1);
        }
    }

    private Vector3 FindPath()
    {
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;
        return direction;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
