using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SkillTree;

public class BulletController : MonoBehaviour
{
    PlayerMovement playerMovement;
    private CombatSystem combatSystem;
    private PlayerManager playerManager;
    [SerializeField] private GameObject explore;
    [Header("Give Dame enemy")]
    [SerializeField] private Transform attackPostition;
    [SerializeField] private Vector2 attackRange;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private int idSkill;
    private int bulletDirection;
    private bool isExplore;
    // Start is called before the first frame update
    void Start()
    {
        isExplore = false;
        playerMovement = FindObjectOfType<PlayerMovement>();
        combatSystem = FindObjectOfType<CombatSystem>();
        playerManager = FindObjectOfType<PlayerManager>();
        bulletDirection = playerMovement.playerDirection;
        //StartCoroutine(DestroyBullet());
    }

    // Update is called once per frame
    void Update()
    {
        BulletMove();
        
    }
    private void BulletMove()
    {
        transform.position += new Vector3(7 * Time.deltaTime * bulletDirection, 0, 0);
    }
    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(1.5f);
        //Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss") && !isExplore)
        {
            isExplore = true;
            var spawnExplore = Instantiate(explore);
            spawnExplore.transform.position = transform.position + new Vector3(0, 0.3f, 0);
            Collider2D[] hitEmenys = Physics2D.OverlapBoxAll(attackPostition.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEmenys)
            {
                if (enemy.gameObject.tag == "Enemy")
                {
                    Debug.Log("We hit" + enemy.gameObject.layer);
                    int playerDame = playerManager.playerAttackPoint;
                    int skillDame = skillTree.skillDamage[idSkill];
                    int dameBullet = playerDame * skillDame;
                    enemy.GetComponent<EnemyHealth>().EnemyTakeDamage(dameBullet);

                }
                if (enemy.gameObject.tag == "Boss")
                {
                    Debug.Log("We hit" + enemy.gameObject.layer);
                    int playerDame = playerManager.playerAttackPoint;
                    int skillDame = skillTree.skillDamage[idSkill];
                    int dameBullet = playerDame * skillDame;
                    enemy.GetComponent<BossController>().BossTakeDame(dameBullet);
                }
            }
            Destroy(spawnExplore, 0.5f);
            gameObject.SetActive(false);
            Destroy(gameObject, 0.5f);
        }
    }

    private void OnDrawGizmos()
    {
        if (attackPostition == null)
            return;
        Gizmos.DrawWireCube(attackPostition.position, attackRange);
    }
}
