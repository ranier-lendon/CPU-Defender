using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FirewallScript : MonoBehaviour, ICostable
{
    private SphereCollider sphereCollider;
    private List<GameObject> malwareList = new List<GameObject>();
    private Coroutine attackCoroutine;
    private GameObject target;

    private int level = 1;

    [SerializeField] private float range;
    private float baseRange = 1.75f;
    private float maxRange = 3f;
    [SerializeField] private float fireRate;
    private float baseFireRate = 1.5f;
    private float maxFireRate = 0.75f;
    [SerializeField] private float damage;
    private int baseCost = 100;
    private float costMultiplier = 1.5f;

    [SerializeField] private GameObject projectile;

    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = baseRange;
    }
    
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

            // Target the first malware on the list.
            target = malwareList[0];

            // Damage the first malware on the list.
            // target.GetComponent<EnemyScript>().TakeDamage(damage);
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
            bullet.GetComponent<ProjectileScript>().Attack(damage, target);
            
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

    public void Upgrade()
    {
        level++;
        damage = level * 25f;
        fireRate = Mathf.Clamp(baseFireRate - (level * 0.1f), maxFireRate, baseFireRate);
        range = Mathf.Clamp(baseRange + (level * 0.125f), baseRange, maxRange);
    }

    public int GetCost()
    {
        return Mathf.RoundToInt(baseCost * Mathf.Pow(costMultiplier, level - 1));
    }
}
