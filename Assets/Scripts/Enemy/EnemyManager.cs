
using System.Threading;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public EnemySpawn[] enemySpawns;

    private void Update()
    {
        for (int i = 0; i < enemySpawns.Length; i++)
        {
            var enemy = enemySpawns[i];
            EnemySpawn enemySpawn = enemy.GetComponentInParent<EnemySpawn>();

            if (enemySpawn.timeCount <= 0)
            {
                enemySpawn.SpawnEnemy();
            }
        }
    }
    
}
