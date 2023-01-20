using UnityEngine;

[RequireComponent(typeof(EnemyPool))]
sealed public class Spawner : MonoBehaviour
{
    public float delaySpawn;
    public bool permanent = false;
    private float timer = 0;
    private EnemyPool pool;
    private void Awake() => pool = GetComponent<EnemyPool>();
    private void Update() 
    {
        timer -= Time.deltaTime;
        if(timer < 0 && pool.Pool.CountActive < pool.maxPoolSize && permanent)
        {
            AddEnemy();
            timer = delaySpawn;
        }
    }
    public void AddGroup(int amountEnemy) 
    {
        for(int i = 0; i < amountEnemy; i++)
            pool.Pool.Get();
    }
    private void AddEnemy() => pool.Pool.Get();
    private void RemoveBall() => pool.Pool.Get().PoolRelease();
}