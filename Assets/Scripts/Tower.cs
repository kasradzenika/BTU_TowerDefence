using UnityEngine;
using System.Collections.Generic;

public class Tower : MonoBehaviour
{
    public List<Transform> targets;
    public GameObject projectilePrefab;
    public Transform spawnPoint;
    public Transform rangeVisual;
    public float range;
    public float fireRate;

    private float lastFireTime = 0f;
    
    private void Start()
    {
        rangeVisual.localScale = Vector3.one * range * 2f;
        transform.GetComponent<SphereCollider>().radius = range;
    }

    private void Update ()
    {
        TryFire();
	}

    public bool TryFire()
    {
        //remove destroyed targets from the top of the list
        while(targets.Count > 0 && targets[0] == null)
        {
            targets.RemoveAt(0);
        }

        //shoot at the first target
        if(targets.Count > 0)
        {
            if (Time.time > lastFireTime + 1f/fireRate)
            {
                GameObject projectileClone = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
                projectileClone.GetComponent<Projectile>().target = targets[0];
                projectileClone.GetComponent<Projectile>().range = range;

                lastFireTime = Time.time;

                return true;
            }
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            targets.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            targets.Remove(other.transform);
        }
    }
}
