using UnityEngine;

sealed public class Vision
{
    public Vector3 directionDamagableObject;
    public Transform target;

    [SerializeField] private float viewRadius;
    private Collider[] hitColliders;
    private LayerMask contactFilter;
    private float minRange = 3;

    public IDamagable CheckFieldOfView(Vector3 position)
    {
        hitColliders = Physics.OverlapSphere(position, viewRadius, contactFilter);
        if(hitColliders.Length > 0)
        {
            for(int indexUnit = 0; indexUnit <= hitColliders.Length; indexUnit++)
            {   
                minRange = (hitColliders[indexUnit].transform.position - position).sqrMagnitude;
                if(hitColliders[indexUnit].transform.TryGetComponent(out IDamagable damagableObject))
                {
                    target = hitColliders[indexUnit].transform;
                    CheckDirection(position);

                    return damagableObject;
                }
            }
        }
        return null;
    }
    private void CheckDirection(Vector3 position) 
    {
        Vector3 vectorY = new Vector3(0, target.position.y, 0);
        directionDamagableObject = (target.position - position - vectorY).normalized;
    }
    public Vision(float viewRadius, LayerMask contactFilter)
    {
        this.viewRadius = viewRadius;
        this.contactFilter = contactFilter;
    }
}