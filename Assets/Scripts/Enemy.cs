using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public float health = 100f;

	void Start ()
    {
        //get destination from the master
        //bad way:
        //Vector3 dest = FindObjectOfType<EnemyMaster>().destination.position;

        //good way:
        Vector3 dest = EnemyMaster.theMaster.destination.position;

        //set destination
        GetComponent<NavMeshAgent>().SetDestination(dest);
	}

    public void GetDamage(float dmg)
    {
        health -= dmg;

        if(health <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
