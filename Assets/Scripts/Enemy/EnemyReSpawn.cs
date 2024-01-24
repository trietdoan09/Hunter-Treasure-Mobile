
using UnityEngine;

public class EnemyReSpawn : MonoBehaviour
{
    [SerializeField] float respawnTimer;
    public float respawnTimeCount;

    EnemyHealth enemyHealth;
    void Start()
    {
        enemyHealth = FindAnyObjectByType<EnemyHealth>();
        respawnTimeCount = respawnTimer;

    }

    void Update()
    {
        if (enemyHealth.dead == true)
        {
            respawnTimeCount -= Time.deltaTime;
            if (respawnTimeCount <= 0)
            {
                enemyHealth.Respawn();
                respawnTimeCount = respawnTimer;
            }
        }
    }
}
