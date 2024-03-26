using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SkillTree;

public class CombatSystem : MonoBehaviour
{
    public static CombatSystem instance;
    public Animator characterAnim;
    public bool isAttack;
    private int timeEndCombo;
    //normal attack
    [Header("Normal attack")]
    [SerializeField] private Transform attackPostition;
    [SerializeField] private Vector2 attackRange;
    [SerializeField] private LayerMask enemyLayers;
    private PlayerManager playerManager;
    [Header("Skill info")]
    [SerializeField] private int idSkill;
    public int skillCoolDown;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        characterAnim = GetComponent<Animator>();
        attackRange = new Vector2(1, 0.5f);
        skillCoolDown = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void NormalAttackCombo()
    {
        if (!isAttack)
        {
            isAttack = true;
            Collider2D[] hitEmenys = Physics2D.OverlapBoxAll(attackPostition.position,attackRange,enemyLayers);
            foreach(Collider2D enemy in hitEmenys)
            {
                if(enemy.name == "Enemy")
                {
                    Debug.Log("We hit" + enemy.name);
                    StartCoroutine(DelayAnimAttack(enemy));
                    //enemy.GetComponent<EnemyHealth>().EnemyTakeDamage(playerManager.playerAttackPoint);
                }
            }
        }
    }
    private IEnumerator DelayAnimAttack(Collider2D enemy)
    {
        yield return new WaitForSeconds(0.5f);
        enemy.GetComponent<EnemyHealth>().EnemyTakeDamage(playerManager.playerAttackPoint);
        yield return null;

    }
    private void OnDrawGizmos()
    {
        if (attackPostition == null)
            return;
        Gizmos.DrawWireCube(attackPostition.position, attackRange);
    }
    public void UseSkill()
    {
        if (skillTree.isActiveSkill[idSkill])
        {
            if (skillCoolDown <= 0)
            {
                skillCoolDown = skillTree.skillCooldown[idSkill];
                if(idSkill> 3 && idSkill < 7)
                {
                    StartCoroutine(UseSkillAnim());
                }
                StartCoroutine(StartskillCoolDownnSkill());
            }
        }
    }
    IEnumerator UseSkillAnim()
    {
        characterAnim.SetBool("UseSkill" + (idSkill - 3), true);
        yield return new WaitForSeconds(0.8f);
        characterAnim.SetBool("UseSkill" + (idSkill - 3), false);
        yield return null;
    }
    private IEnumerator StartskillCoolDownnSkill()
    {
        while (skillCoolDown > 0)
        {
            skillCoolDown--;
            yield return new WaitForSeconds(1f);
        }
    }
}
