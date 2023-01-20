using UnityEngine;
using UnityEngine.AI;

public class BaseMovementBehaviour : IMovementBehaviour
{
    [SerializeField] protected Transform target;
    protected NavMeshAgent agent;
    public virtual void Move() => agent.destination = target.position;
}