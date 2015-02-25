using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject players;
    public float slerp = 5;
    private Vector3 lookAtPoint;
    private Vector3 localForwardVector;
    private float distance;
    public float maximumDistance;
    public float minimumDistance;
    public Transform cameraTransform;

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
    }

    void UpdatePosition()
    {
        transform.position = Vector3.Slerp(transform.position, players.transform.position, slerp * Time.deltaTime);
    }
    void UpdateZoom()
    {
        cameraTransform.localPosition = lookAtPoint - localForwardVector * distance;
    }
    void UpdateDistance()
    {
        distance = Mathf.Clamp(distance, minimumDistance, maximumDistance);
    }
}
