using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject playerContainer;
    public float slerp = 5;
    private Vector3 lookAtPoint;
    private Vector3 localForwardVector;
    private float distance;
    public float maximumDistance;
    public float minimumDistance;
    public Transform cameraTransform;
    private Vector3 center;

    void Start()
    {
        localForwardVector = cameraTransform.forward;
        distance = Mathf.Clamp(-cameraTransform.localPosition.z / cameraTransform.forward.z, minimumDistance, maximumDistance);
        lookAtPoint = cameraTransform.localPosition + localForwardVector * distance;
        
    }

    void LateUpdate()
    {
        UpdateDistance();
        UpdateZoom();
        UpdatePosition();
        UpdateCenter();
    }

    void UpdatePosition()
    {
        transform.position = Vector3.Slerp(transform.position, center, slerp * Time.deltaTime);
    }
    void UpdateZoom()
    {
        cameraTransform.localPosition = lookAtPoint - localForwardVector * distance;
    }
    void UpdateDistance()
    {
        distance = Mathf.Clamp(distance, minimumDistance, maximumDistance);
    }

    void UpdateCenter()
    {
        Vector3 positions = Vector3.zero;

        foreach (Transform child in playerContainer.transform)
        {
            positions += child.position;
        }

        if (playerContainer.transform.childCount > 0)
            center = positions / playerContainer.transform.childCount;
        else
            center = playerContainer.transform.position;
    }
}
