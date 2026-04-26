using UnityEngine;

public class HoneypotScript : MonoBehaviour
{
    private int level = 1;
    private float slowDownRate = 0.10f;
    
    // If they enter the range they will be slowed down
    void OnTriggerEnter(Collider other)
    {
        // Checks if the object is a malware
        // Bullets can also be slowed down by this!
        if (other.CompareTag("Malware"))
        {
            Debug.Log("Honeypot hit: " + other.name);
            // Slows down the malware
            float baseSpeed = other.GetComponent<EnemyScript>().GetBaseMovementSpeed();
            other.GetComponent<EnemyScript>().SetMovementSpeed(baseSpeed * (1-slowDownRate*level));
            Debug.Log(other.GetComponent<EnemyScript>().GetMovementSpeed());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Malware"))
        {
            Debug.Log("Honeypot exit: " + other.name);
            // Resets the malware speed
            float baseSpeed = other.GetComponent<EnemyScript>().GetBaseMovementSpeed();
            other.GetComponent<EnemyScript>().SetMovementSpeed(baseSpeed);
            Debug.Log(other.GetComponent<EnemyScript>().GetMovementSpeed());
        }
    }

    
    

}
