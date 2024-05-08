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
    private PlayerMovement playerMovement;
    [Header("Skill info")]
    public GameObject buttonSkillHolder;
    public List<PlayerUseSkill> useSkills;
    public int idSkill;
    public int[] skillCoolDown;
    public int buttonCallUseSkill;
    private int[] manaUse;
    [Header("Spawn Skill")]
    [SerializeField] private List<GameObject> spawnSkills;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        characterAnim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        attackRange = new Vector2(1, 0.5f);
        skillCoolDown = new int[3] { 0, 0, 0 };
        foreach (var skill in buttonSkillHolder.GetComponentsInChildren<PlayerUseSkill>())
        {
            useSkills.Add(skill);
        }
        for (var i = 0; i < useSkills.Count; i++)
        {
            useSkills[i].buttonId = i;
        }
        StartCoroutine(StartskillCoolDownnSkill());
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
                if(enemy.gameObject.layer == 7)
                {
                    Debug.Log("We hit" + enemy.gameObject.tag);
                    StartCoroutine(DelayAnimAttack(enemy));
                }
                else if(enemy.gameObject.tag == "Boss")
                {
                    Debug.Log("We hit " + enemy.gameObject.tag);
                    StartCoroutine(DelayAnimAttack(enemy)); 
                }
            }
        }
    }
    private IEnumerator DelayAnimAttack(Collider2D enemy)
    {
        yield return new WaitForSeconds(0.5f);
        if(enemy.gameObject.layer == 7)
        {
            enemy.GetComponent<EnemyHealth>().EnemyTakeDamage(playerManager.playerAttackPoint);
        }
        if(enemy.gameObject.tag == "Boss")
        {
            Debug.Log("Give dame boss");
            enemy.GetComponent<BossController>().BossTakeDame(playerManager.playerAttackPoint);
        }
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
            if (skillCoolDown[buttonCallUseSkill] <= 0)
            {
                if(idSkill == 4 && playerManager.playerCurrentManaPoint >= 50 || idSkill == 5 && playerManager.playerCurrentManaPoint >= 100 
                    || idSkill == 6 && playerManager.playerCurrentManaPoint >= 200)
                {
                    skillCoolDown[buttonCallUseSkill] = skillTree.skillCooldown[idSkill];
                    StartCoroutine(UseSkillAnim());
                }
            }
        }
    }
    public void SpawnSkillWizard()
    {
        for(int i=0; i < spawnSkills.Count; i++)
        {
            if (i == idSkill - 4)
            {
                var spawnSkill = Instantiate(spawnSkills[i]);
                spawnSkill.transform.position = transform.position + new Vector3(1 * playerMovement.playerDirection, 0, 0);
                spawnSkill.transform.localScale = new Vector3(1 * playerMovement.playerDirection, 1, 1);
            }
        }
    }
    public void SetSkillSpawn()
    {
        switch (playerManager.characterClass)
        {
            case CharacterClass.Wizard:
                {
                    SpawnSkillWizard();
                    break;
                }
        }
    }
    IEnumerator UseSkillAnim()
    {
        characterAnim.SetBool("UseSkill" + (idSkill - 3), true);
        yield return new WaitForSeconds(0.8f);
        SetSkillSpawn();
        characterAnim.SetBool("UseSkill" + (idSkill - 3), false);
        yield return null;
    }
    private IEnumerator StartskillCoolDownnSkill()
    {
        while (true)
        {
            for(int i = 0; i < skillCoolDown.Length; i++)
            {
                if (skillCoolDown[i] > 0)
                    skillCoolDown[i]--;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
