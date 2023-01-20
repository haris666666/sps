using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(HealthView))]
abstract public class Unit : MonoBehaviour, IDamagable
{
    public (float, float) health; //(now, max) health
    public HealthView healthView;

    protected IMovementBehaviour movement;
    protected IAttackBehaviour attacking;
    protected IDamagable target;

    protected Vision vision;
    protected NavMeshAgent agent;
    protected bool deathed = false;

    [SerializeField] protected LayerMask contactFilter;

    public void Awake() => healthView = GetComponent<HealthView>();
    public virtual void GetDamaged(int amountDamage) 
    {
        health.Item1 -= amountDamage;

        healthView.UpdateHealthBar(health);
        healthView.CreateTextChangedHealth(amountDamage);

        if(health.Item1 <= 0)
            deathed = true;
    }
    protected void Move() => movement.Move();
    protected void Attack(int amountDamage) => attacking.Attack(amountDamage, target);
} 