using UnityEngine;
using UnityEngine.AI;

sealed public class PlayerMovementBehaviour : BaseMovementBehaviour
{
    private bool canMove = false;
    private void UpdateTargetPosition() => target.position += new Vector3(20, 0, 0);
    public override void Move() => base.Move();
    public void ChangeSpeed() 
    {
        canMove = !canMove;
        if(canMove) agent.speed = 2;
        else agent.speed = 0;
    }

    public PlayerMovementBehaviour(NavMeshAgent agent, Transform target)
    {
        this.target = target;
        this.agent = agent;

        StageManager.Instance.OnChangedStage += ChangeSpeed;
    }
}