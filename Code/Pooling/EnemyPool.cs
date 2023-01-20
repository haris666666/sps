using UnityEngine;
using UnityEngine.Pool;
using System.Collections;

sealed public class EnemyPool : MonoBehaviour
{
    public GameObject enemyPrefab;
    public bool collectionChecks = true;
    public int maxPoolSize;

    private ObjectPool<Enemy> m_Pool;
    public ObjectPool<Enemy> Pool
    {
        get
        {
            if (m_Pool == null)
                m_Pool = new ObjectPool<Enemy>(CreateEnemy, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, 10, maxPoolSize);
            return m_Pool;
        }
    }
    private Enemy CreateEnemy()
    {
        GameObject go = Instantiate(enemyPrefab, transform);
        go.transform.localPosition += new Vector3(0, 0, Random.Range(-2, 2));

        Enemy enemy = go.AddComponent<Enemy>();
        enemy.pool = m_Pool;

        return enemy;
    }
    private void OnReturnedToPool(Enemy enemy) => enemy.gameObject.SetActive(false);
    private void OnTakeFromPool(Enemy enemy) => enemy.gameObject.SetActive(true);
    private void OnDestroyPoolObject(Enemy enemy) => Destroy(enemy.gameObject);
}