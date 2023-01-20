using UnityEngine;
using UnityEngine.AI;

sealed public class HumanoidMovementBehaviour : BaseMovementBehaviour
{
    private Vision vision;
    private Transform transformObject;
    
    public override void Move()
    {
        FindTarget();
        if(target)
            base.Move();
        else agent.destination = transformObject.position + Vector3.left;
    }
    private void FindTarget() => target = vision.target;
    public HumanoidMovementBehaviour(NavMeshAgent agent, Vision vision, Transform transformObject) 
    {
        this.agent = agent;
        this.vision = vision;
        this.transformObject = transformObject;
    }
}