using UnityEngine;

public class CPUScript : MonoBehaviour
{
    private int health = 3;

    [SerializeField] private GameObject healthBar;

    public void TakeDamage()
    {
        health--;
        
        // Calculate the health percentage (a value between 0.0 and 1.0)
        float healthPercentage = (float)health / 3f;

        // Apply length of hp
        healthBar.transform.localScale = new Vector3(healthPercentage, healthBar.transform.localScale.y, healthBar.transform.localScale.z); 

        if (health <= 0)
        {
            GameManager.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Malware"))
        {
            TakeDamage();
        }
    }
}
