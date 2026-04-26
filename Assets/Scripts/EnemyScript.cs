using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float health = 100f;

    private int currentWaypoint = 0;
    private float movementSpeed;
    [SerializeField] private float baseMovementSpeed = 1f;

    private GameObject[] waypoints;
    private Rigidbody rb;

    public int portSpawned = 1;

    void Start()
    {
        // Get the rigidbody component
        rb = GetComponent<Rigidbody>();

        // Find the ports path
        waypoints = GameObject.Find("Ports").transform.GetChild(portSpawned).GetComponent<PortPath>().GetWaypoints();

        // Set the base movement speed
        movementSpeed = baseMovementSpeed;
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + FindPath() * Time.fixedDeltaTime * movementSpeed);

        GameObject nextWaypoint = waypoints[currentWaypoint + 1];
        // Checks if the enemy has reached the target waypoint
        if (Vector3.Distance(transform.position, nextWaypoint.transform.position) < 0.05f)
        {
            // Increments the current waypoint
            currentWaypoint++;
        }
    }

    private Vector3 FindPath()
    {
        GameObject nextWaypoint = waypoints[currentWaypoint + 1];
    
        Vector3 direction = (nextWaypoint.transform.position - transform.position).normalized;
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

    public float GetMovementSpeed()
    {
        return movementSpeed;
    }

    public void SetMovementSpeed(float speed)
    {
        movementSpeed = speed;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public float GetBaseMovementSpeed()
    {
        return baseMovementSpeed;
    }
}
