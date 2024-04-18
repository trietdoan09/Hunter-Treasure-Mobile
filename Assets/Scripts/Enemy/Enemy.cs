
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]

public class Enemy : ScriptableObject
{
    public string enemyName;
    public int enemyLevel;
    public float enemySpeed;
    public int enemyMaxHealth;
    public int enemyDamage;
    public int enemyDef;

}
