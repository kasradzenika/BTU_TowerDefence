using UnityEngine;

public class InputController : MonoBehaviour
{
    public float raycastDist = 100f;
    public LayerMask clickMask;

    private Ray ray;
    private RaycastHit hit;
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit, raycastDist, clickMask);

            if(hit.transform != null)
            {
                if(hit.transform.tag == "TowerSpot")
                {
                    TowersMaster.instance.SpawnTowerOnSpot(hit.transform);
                }
            }
        }
	}
}
