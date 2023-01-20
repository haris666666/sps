using UnityEngine;

sealed public class RangeAttackBehaviour : IAttackBehaviour
{
    public void Attack(int amountDamage, IDamagable target) => target.GetDamaged(amountDamage);
}