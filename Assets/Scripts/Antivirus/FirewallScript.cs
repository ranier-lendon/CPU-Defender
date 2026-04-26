using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FirewallScript : MonoBehaviour
{
    private List<GameObject> malwareList = new List<GameObject>();
    private Coroutine attackCoroutine;
    private GameObject target;

    private int level = 1;
    private int maxLevel = 5;

    [SerializeField] private float range;
    [SerializeField] private float fireRate;
    [SerializeField] private float damage;

    IEnumerator Fire()
    {
        while (true)
        {
            // Clears the list of null items (dead malwares).
            malwareList.RemoveAll(item => item == null);

            if (malwareList.Count == 0)
            {
                attackCoroutine = null;
                yield break;
            }

            // 
            target = malwareList[0];

            // Damage the first malware on the list.
            target.GetComponent<EnemyScript>().TakeDamage(damage);
            
            yield return new WaitForSeconds(fireRate);
        }

    }

    // Checks if enemy enters the firewall
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Malware"))
        {
            malwareList.Add(other.gameObject);
            
            // Starts the attack if not started.
            if (attackCoroutine == null)
            {
                target = malwareList[0];
                attackCoroutine = StartCoroutine(Fire());
            }
        }
    }

    // Checks if enemy exits the firewall
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Malware"))
        {
            malwareList.Remove(other.gameObject);
        }
    }
}
