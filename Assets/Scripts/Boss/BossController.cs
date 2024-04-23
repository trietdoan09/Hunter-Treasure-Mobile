using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public enum BossState
    {
        Waiting,
        NormalAttack,
        SkillAttack
    }
    PlayerManager playerManager;
    PlayerMovement playerMovement;
    Transform playerPos;
    Rigidbody2D rigidbody2D;
    BoxCollider2D boxCollider2D;
    Animator animator;
    private bool isFlipped;
    [Header("Boss infomation")]
    public BossState bossBehaviour;
    [SerializeField] private float speed;
    [SerializeField] private float tempSpeed;
    [SerializeField] private int bossId;
    [SerializeField] private float atkRange;
    [SerializeField] private bool phase2;
    [SerializeField] private bool immortalTime;
    [SerializeField] private bool enraged;
    [SerializeField] private bool isDead;
    [SerializeField] private float enragedTime;
    [SerializeField] private int bossMaxHealthPoint;
    [SerializeField] private int bossCurrentHealthPoint;
    [SerializeField] private int bossDefend;
    public int bossAttackDame;
    [SerializeField] private int tempBossDefend;
    [SerializeField] private int tempBossAttackDame;
    [SerializeField] private GameObject[] skills;
    [SerializeField] private Transform attackPostition;
    [SerializeField] private Vector2 attackRange;
    [SerializeField] private LayerMask enemyLayers;
    bool isCoolDown;
    // Start is called before the first frame update
    void Start()
    {
        bossBehaviour = BossState.Waiting;
        SetupBossStatus();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        playerManager = GameObject.FindObjectOfType<PlayerManager>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        StartCoroutine(BossBehaviour());
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            MoveToPlayer();
        }
    }
    private void SetupBossStatus()
    {
        bossMaxHealthPoint = 200;
        bossCurrentHealthPoint = bossMaxHealthPoint;
        bossDefend = 50;
        bossAttackDame = 100;
        speed = 3f;
        tempSpeed = speed;
        atkRange = 2f;
        phase2 = false;
        enraged = false;
        tempBossAttackDame = bossAttackDame;
        tempBossDefend = bossDefend;
        enragedTime = 10f;
        isCoolDown = false;
    }
    private void MoveToPlayer()
    {
        LookAtPlayer();
        Vector2 target = new Vector2(playerPos.position.x, rigidbody2D.position.y);
        Vector2 newPos = Vector2.MoveTowards(rigidbody2D.position, target, speed * Time.fixedDeltaTime);
        rigidbody2D.MovePosition(newPos);
        animator.SetFloat("speed", speed);
    }
    private void LookAtPlayer()
    {
        if (transform.position.x > playerPos.position.x && isFlipped)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            //transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < playerPos.position.x && !isFlipped)
        {
            transform.localScale = new Vector3(1, 1, 1);
            //transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
    public void BossTakeDame(int damage)
    {
        if (!immortalTime)
        {
            var dameTaken = damage - bossDefend > 0 ? damage - bossDefend : 0;
            if (bossCurrentHealthPoint - dameTaken <= 0)
            {
                bossCurrentHealthPoint = 0;
                immortalTime = true;
                StopAllCoroutines();
                speed = 0;
                if (!phase2)
                {
                    //enter phase 2
                    phase2 = true;
                    //load anim angry
                    StartCoroutine(LoadAnimPhase2());
                    //set current hp return full
                    bossCurrentHealthPoint = bossMaxHealthPoint;
                    // increase status
                    StartCoroutine(BossEnraged());
                }
                else
                {
                    //dead
                    isDead = true;
                    StopAllCoroutines();
                    boxCollider2D.enabled = false;
                    rigidbody2D.gravityScale = 0;
                    animator.SetTrigger("isDead");
                }
            }
            else
            {
                Debug.Log("Boss take dame");
                bossCurrentHealthPoint -= dameTaken;
            }
        }
    }
    IEnumerator LoadAnimPhase2()
    {
        animator.SetBool("enraged", true);
        yield return new WaitForSeconds(5f);
        animator.SetBool("enraged", false);
        StartCoroutine(BossBehaviour());
        immortalTime = false;
        yield return null;
    }
    IEnumerator BossEnraged()
    {
        while (true)
        {
            if (enragedTime > 0)
            {
                bossAttackDame = tempBossAttackDame * 3;
                bossDefend = tempBossDefend / 3;
                enragedTime -= 1;
            }
            else if (enragedTime <= 0 && !isCoolDown)
            {
                isCoolDown = true;
                bossAttackDame = tempBossAttackDame;
                bossDefend = tempBossDefend / 5;
                StartCoroutine(CoolDownEnragedTime());
            }
            yield return new WaitForSeconds(1f);
        }
    }
    IEnumerator CoolDownEnragedTime()
    {
        yield return new WaitForSeconds(10f);
        enragedTime = 10f;
        isCoolDown = false;
    }
    private void Attack()
    {
        if (Vector2.Distance(playerPos.position, rigidbody2D.position) <= atkRange)
        {
            //attack
            Debug.Log("Boss normal attack");
            animator.SetTrigger("isAttack");
            Collider2D[] hitEmenys = Physics2D.OverlapBoxAll(attackPostition.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEmenys)
            {
                if (enemy.gameObject.tag == "Player")
                {
                    Debug.Log("We hit" + enemy.gameObject.tag);
                    playerManager.PlayerTakeDame(bossAttackDame);
                }
            }
            bossBehaviour = BossState.Waiting;
        }
    }
    private void OnDrawGizmos()
    {
        if (attackPostition == null)
            return;
        Gizmos.DrawWireCube(attackPostition.position, attackRange);
    }
    private void UseSkill()
    {
        Debug.Log("Boss use skill");
        StartCoroutine(RandomSkill());
        bossBehaviour = BossState.Waiting;
    }
    IEnumerator LoadAnimUseSkill(int skillId)
    {
        animator.SetBool("useSkill" + skillId, true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("useSkill" + skillId, false);
        yield return null;
    }
    IEnumerator RandomSkill()
    {
        bool isRight = transform.position.x < playerPos.position.x ? true : false;
        if (phase2)
        {
            if (bossCurrentHealthPoint < bossCurrentHealthPoint / 2)
            {
                var randomAmount = Random.Range(1, 6);
                for (int i = 0; i < randomAmount; i++)
                {
                    var randomSkill = Random.Range(0, 3);
                    StartCoroutine(LoadAnimUseSkill(randomSkill));
                    yield return new WaitForSeconds(0.2f);
                    var _skillSpawn = Instantiate(skills[randomSkill]);
                    if (randomSkill < 2)
                    {
                        _skillSpawn.transform.localScale = isRight ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);
                        _skillSpawn.transform.position = isRight ? gameObject.transform.position + new Vector3(1, -0.5f, 0) : gameObject.transform.position + new Vector3(-1, -0.5f, 0);
                        _skillSpawn.GetComponent<BossSkillController>().direction = isRight ? 1 : -1;
                        _skillSpawn.GetComponent<BossSkillController>().idSkill = randomSkill;
                    }
                    else // skill 3
                    {
                        _skillSpawn.transform.position = playerPos.position + new Vector3(0.5f * i * playerMovement.playerDirection, 3.5f, 0);
                        _skillSpawn.GetComponent<BossSkillController>().idSkill = randomSkill;
                    }
                    yield return new WaitForSeconds(0.5f);
                }
            }
            else
            {
                var randomSkill = Random.Range(0, 3);
                StartCoroutine(LoadAnimUseSkill(randomSkill));
                yield return new WaitForSeconds(0.2f);
                var randomAmount = Random.Range(1, 6);
                for (int i = 0; i < randomAmount; i++)
                {
                    var _skillSpawn = Instantiate(skills[randomSkill]);
                    //skill 1, 2
                    if (randomSkill < 2)
                    {
                        _skillSpawn.transform.localScale = isRight ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);
                        _skillSpawn.transform.position = isRight ? gameObject.transform.position + new Vector3(1, -0.5f, 0) : gameObject.transform.position + new Vector3(-1, -0.5f, 0);
                        _skillSpawn.GetComponent<BossSkillController>().direction = isRight ? 1 : -1;
                        _skillSpawn.GetComponent<BossSkillController>().idSkill = randomSkill;
                    }
                    else // skill 3
                    {
                        _skillSpawn.transform.position = playerPos.position + new Vector3(0.5f * i * playerMovement.playerDirection, 3.5f, 0);
                        _skillSpawn.GetComponent<BossSkillController>().idSkill = randomSkill;
                    }
                    yield return new WaitForSeconds(0.5f);
                }
            }
        }
        else
        {
            StartCoroutine(LoadAnimUseSkill(0));
            yield return new WaitForSeconds(0.2f);
            var _skillSpawn = Instantiate(skills[0]);
            _skillSpawn.transform.localScale = isRight ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);
            _skillSpawn.transform.position = isRight ? gameObject.transform.position + new Vector3(1, -0.5f, 0) : gameObject.transform.position + new Vector3(-1, -0.5f, 0);
            _skillSpawn.GetComponent<BossSkillController>().direction = isRight ? 1 : -1;
            _skillSpawn.GetComponent<BossSkillController>().idSkill = 0;
        }
        yield return null;
    }
    IEnumerator BossBehaviour()
    {
        while (true)
        {
            // chi thuc hien hanh dong tiep theo khi hanh dong truoc do hoan thanh
            switch (bossBehaviour)
            {
                case BossState.Waiting:
                    {
                        speed = tempSpeed;
                        bossBehaviour = Vector2.Distance(playerPos.position, rigidbody2D.position) > 5f ? BossState.SkillAttack : BossState.NormalAttack;
                        break;
                    }
                case BossState.NormalAttack:
                    {
                        speed = tempSpeed;
                        if (Vector2.Distance(playerPos.position, rigidbody2D.position) > 5f)
                        {
                            bossBehaviour = BossState.SkillAttack;
                        }
                        else
                        {
                            Attack();
                        }
                        break;
                    }
                case BossState.SkillAttack:
                    {
                        speed = 0;
                        UseSkill();
                        break;
                    }
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
