using UnityEngine;

sealed public class LocationMovement : MonoBehaviour
{
    public Transform location;
    public void Move() => location.position += new Vector3(20, 0, 0);
}