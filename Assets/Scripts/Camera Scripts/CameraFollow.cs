using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The transform of the object that the camera should follow
    public float smoothSpeed = 0.125f; // The speed at which the camera should move towards the target

    private Vector3 offset; // The offset between the camera and the target

    void Start()
    {
        offset = transform.position - target.position; // Calculate the initial offset between the camera and the target
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // Calculate the desired position of the camera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Smoothly move the camera towards the desired position
        transform.position = smoothedPosition; // Update the position of the camera
    }
}