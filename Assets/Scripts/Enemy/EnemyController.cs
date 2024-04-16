using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Enemy enemy;

    WorldLevel worldLevel;

    public string enemyName;
    public int enemyLevel;
    public float enemySpeed;
    public int enemyMaxHealth;
    public int enemyDamage;
    public int enemyDef;

    public TextMeshProUGUI enemyLevelTxt;

    public void Awake()
    {
        worldLevel = GetComponent<WorldLevel>();

        enemyName = enemy.name;

        enemySpeed = enemy.enemySpeed;
        enemyLevel = enemy.enemyLevel;

        enemyMaxHealth = enemy.enemyMaxHealth;
        enemyDamage = enemy.enemyDamage;
        enemyDef = enemy.enemyDef;
    }
    private void InitialiseEnemy()
    {
        var worldLevels = worldLevel.worldLevel;

        enemyLevel = Random.Range((1 * worldLevels),(10 * worldLevels));
        enemyLevelTxt.text = enemyLevel + " ".ToString();

        enemyMaxHealth = enemyMaxHealth * enemyLevel;

        enemyDamage = enemyDamage * enemyLevel;

        enemyDef = enemyDef * enemyLevel;
    }
}
