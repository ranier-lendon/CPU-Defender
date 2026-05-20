using UnityEngine;

public class HoneypotScript : MonoBehaviour, ICostable
{
    private SphereCollider col;

    private int level = 1;
    private float slowDownRate = 0.10f;
    private int maxLevel = 5;
    [SerializeField] private float range = 2f;

    private int[] cost = {300, 600, 1000, 2500};

    void Start()
    {
        // Get the sphere collider
        col = GetComponent<SphereCollider>();
        // Update the range
        UpdateRange();
    }
    
    // If they enter the range they will be slowed down
    void OnTriggerEnter(Collider other)
    {
        // Checks if the object is a malware
        // Bullets can also be slowed down by this!
        if (other.CompareTag("Malware"))
        {
            // Slows down the malware
            float baseSpeed = other.GetComponent<EnemyScript>().GetBaseMovementSpeed();
            other.GetComponent<EnemyScript>().SetMovementSpeed(baseSpeed - slowDownRate*level);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Malware"))
        {
            // Resets the malware speed
            float baseSpeed = other.GetComponent<EnemyScript>().GetBaseMovementSpeed();
            other.GetComponent<EnemyScript>().SetMovementSpeed(baseSpeed);
        }
    }

    void UpdateRange()
    {
        // Updates the range
        col.radius = range + (0.25f * (level-1));
    }

    public void Upgrade()
    {
        level++;

        // Updates the range of honeypot if got upgraded.
        UpdateRange();
    }

    public int GetCost()
    {
        if (level >= maxLevel)
        {
            // Returns 0 if cannot be upgraded
            return 0;
        }
        else 
        {
            // Returns the cost of the next upgrade
            return cost[level-1];
        }
    }
}
