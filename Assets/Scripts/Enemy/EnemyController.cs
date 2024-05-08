using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Enemy enemy;

    WorldLevel worldLevel;
    SkillEnemyRange skillEnemyRange;

    public string enemyName;
    public int enemyLevel;
    public float enemySpeed;
    public int enemyMaxHealth;
    public int enemyDamage;
    public int enemyDef;

    public TextMeshProUGUI enemyLevelTxt;

    public void Awake()
    {
        worldLevel = FindAnyObjectByType<WorldLevel>();
        skillEnemyRange = FindAnyObjectByType<SkillEnemyRange>();

        InitialiseEnemy();
    }
    public void InitialiseEnemy()
    {
        ResetEnemy();

        var worldLevels = worldLevel.worldLevel;

        var level = worldLevels == 1 ? 1 : (worldLevels- 1) * 10;

        enemyLevel = Random.Range((level),(10 * worldLevels));
        enemyLevelTxt.text = "Lv." + enemyLevel + " " + enemyName.ToString();

        enemyMaxHealth = enemyMaxHealth * enemyLevel;

        enemyDamage = enemyDamage * enemyLevel;

        enemyDef = enemyDef * enemyLevel;

    }

    public void ResetEnemy()
    {
        enemyName = enemy.name;
        enemySpeed = enemy.enemySpeed;
        enemyLevel = enemy.enemyLevel;

        enemyMaxHealth = enemy.enemyMaxHealth;
        enemyDamage = enemy.enemyDamage;
        enemyDef = enemy.enemyDef;
    }
}
