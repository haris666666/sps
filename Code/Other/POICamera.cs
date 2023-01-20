using UnityEngine;

public class POICamera : MonoBehaviour
{
    public Transform go;
    public Vector3 shift;

    private void Update()
    {
        transform.position = new Vector3(go.position.x, transform.position.y, transform.position.z);
        transform.position += shift;
    }
}
