using UnityEngine;

public class LookToCamera : MonoBehaviour
{
    private Transform cameraTransform;

    private void Start() => cameraTransform = Camera.main.transform;
    private void Update() => transform.rotation = Quaternion.LookRotation(transform.position - cameraTransform.position, Vector3.up);
}
