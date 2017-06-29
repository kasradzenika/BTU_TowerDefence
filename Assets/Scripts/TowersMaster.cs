using UnityEngine;

public class TowersMaster : MonoBehaviour
{
    public int TowerCost;
    public Transform towerPrefab;

    public static TowersMaster instance;

    private void Awake()
    {
        instance = this;
    }

    public void SpawnTowerOnSpot(Transform towerSpot)
    {
        if(ResourcesController.instance.Money >= TowerCost)
        {
            ResourcesController.instance.Money -= TowerCost;

            if (towerSpot.childCount == 0)
            {
                Transform tClone = Instantiate(towerPrefab, towerSpot);
                tClone.localPosition = Vector3.zero;
                tClone.localRotation = Quaternion.identity;
            }
            else
            {
                Debug.Log("Spot already has a tower");
            }
        }
    }

    public void DestroyTowerOnSpot(Transform towerSpot)
    {
        if (towerSpot.childCount == 1)
        {
            Destroy(towerSpot.GetChild(0).gameObject);
        }
        else
        {
            Debug.LogError("There's no tower on this spot");
        }
    }
}
