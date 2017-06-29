using UnityEngine;

public class CameraController : MonoBehaviour
{
    //mouse movemetn settings
    public float speed;
    public float zoom;
    public float farZoom;
    public float nearZoom;

    //flying settings
    public Transform focusTarget;
    public float stoppingDistance = 0.1f;
    public bool isFlyingToTarget = false;
    public float flyingSpeed = 5f;
	
	void Update ()
    {
        MoveCamera();
        ZoomCamera();

        //fly camera to player
        if (Input.GetKeyDown(KeyCode.F))
        {
            isFlyingToTarget = true;
        }
	}

    void MoveCamera()
    {
        if(isFlyingToTarget)
        {
            FlyCameraToPlayer();
        }
        else
        {
            MoveCameraWithMouse();
        }
    }

    void FlyCameraToPlayer()
    {
        //stop flying to player, if near enough
        Vector3 coordinateDifference = transform.position - focusTarget.position;
        float distanceToPlayer = coordinateDifference.magnitude;

        if (distanceToPlayer < stoppingDistance)
        {
            isFlyingToTarget = false;
            return;
        }

        //fly me to the player
        transform.position = Vector3.Lerp(transform.position, focusTarget.position, flyingSpeed * Time.deltaTime);
    }

    void MoveCameraWithMouse()
    {
        Vector3 pos = transform.position;

        //vertical movement
        if (Input.mousePosition.y >= Screen.height - 1)
        {
            pos.z += speed * Time.deltaTime;
        }
        else if (Input.mousePosition.y <= 0)
        {
            pos.z -= speed * Time.deltaTime;
        }

        //horizontal movement
        if (Input.mousePosition.x >= Screen.width - 1)
        {
            pos.x += speed * Time.deltaTime;
        }
        else if (Input.mousePosition.x <= 0)
        {
            pos.x -= speed * Time.deltaTime;
        }
        
        transform.position = pos;
    }

    void ZoomCamera()
    {
        zoom -= Input.mouseScrollDelta.y;

        //if (zoom < minZoom)
        //    zoom = minZoom;
        //else if (zoom > maxZoom)
        //    zoom = maxZoom;
        //is same as this code:
        zoom = Mathf.Clamp(zoom, farZoom, nearZoom);

        Vector3 pos = Camera.main.transform.localPosition;
        pos.z = zoom;
        Camera.main.transform.localPosition = pos;
    }
}
