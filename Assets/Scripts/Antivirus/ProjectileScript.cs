using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private GameObject _targetMalware;
    private float _damage;
    private Rigidbody rb;
    private float _speed = 2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    public void Attack(float damage, GameObject targetMalware)
    {
        _damage = damage;
        _targetMalware = targetMalware;
    }

    private Vector3 FindPath()
    {
        if (_targetMalware != null) 
        {
            Vector3 direction = (_targetMalware.transform.position - transform.position).normalized;
            return direction;
        } 
        else 
        {
            Destroy(gameObject);
            return Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + FindPath() * Time.fixedDeltaTime * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _targetMalware)
        {
            _targetMalware.GetComponent<EnemyScript>().TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
