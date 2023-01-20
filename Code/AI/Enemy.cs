using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

sealed public class Enemy : Unit
{
    public ObjectPool<Enemy> pool;
    [SerializeField] private WeaponData weaponData;
    private float timer = 1;

    public void ChangeWeapon(WeaponData weaponData) 
    {
        this.weaponData = weaponData;
        attacking = weaponData.attackBehaviour;
    } 
    public void PoolRelease() 
    {
        transform.localPosition = Vector3.zero + new Vector3(0, 0, Random.Range(-1.75f, 1.75f));
        PurchaseSystem.Instance.AddMoney(250);

        health.Item1 = health.Item2;
        deathed = false;
        healthView.UpdateHealthBar(health);

        StageManager.Instance.AmountActiveEnemiesInStage--;
        pool.Release(this);
    }
    public override void GetDamaged(int amountDamage)
    {
        base.GetDamaged(amountDamage);
        if(deathed) PoolRelease();
    }
    void Start() //не успел с зенджектом
    {
        agent = GetComponent<NavMeshAgent>();
        contactFilter = LayerMask.GetMask("Player");
        vision = new Vision(1.5f, contactFilter);
        this.movement = new HumanoidMovementBehaviour(agent, vision, transform);
        this.health = (100f, 100f);
        this.weaponData = new WeaponData(0, 1, 10, 1, new RangeAttackBehaviour());
        attacking = new RangeAttackBehaviour();
    }
    public Enemy(IMovementBehaviour movement, WeaponData weaponData, (int, int) health)
    {
        this.movement = movement;
        this.health = health;
        this.weaponData = weaponData;
        attacking = new RangeAttackBehaviour();
    }
    private void Update() 
    {
        Move();
        FindTarget();

        if(target != null)
        {
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                Debug.Log("attack");
                Attack(weaponData.damage);
                timer = weaponData.delayAttack;
            }
        }
    }
    private void FindTarget() => target = vision.CheckFieldOfView(transform.position);
}