
using UnityEngine;

public class EnemyReSpawn : MonoBehaviour
{

    public float maxRange;

    [SerializeField] GameObject enemy;
    [SerializeField] Transform enemyPos;

    [SerializeField] float timeRespawn;
    [SerializeField] float timeCount;
    [SerializeField] int maxCount;
    [SerializeField] int posCount;

    int enemyCount;

    EnemyHealth enemyHealth;

    void Start()
    {
        enemyHealth = FindAnyObjectByType<EnemyHealth>();
        timeCount = timeRespawn;
    }


    void Update()
    {
        if(enemyHealth.dead ==  true)
        {
            timeCount -= Time.deltaTime;
            if (timeCount < 0)
            {
                enemyHealth.dead = false;
                Spawn();
                timeCount = timeRespawn;
            }
        }
    }
    private void Spawn()
    {
        //if (enemyCount >= maxCount) return;

         Instantiate(enemy, enemyPos);
    }
}
