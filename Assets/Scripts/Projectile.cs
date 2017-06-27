using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform target;
    public float damage = 10f;
    public float speed = 1f;
    public float range = 1f;
    public float lifeSpan = 1f;

    private Vector3 moveDirection;
    
    private void Start()
    {
        Destroy(gameObject, lifeSpan);
    }

    void Update ()
    {
        if (target)
        {
            moveDirection = target.position - transform.position;
            moveDirection = moveDirection.normalized;
        }

        transform.position += moveDirection * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
            other.GetComponent<Enemy>().GetDamage(damage);
        }
        else if (other.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
