using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    Transform playerPos;
    Rigidbody2D rigidbody2D;
    Animator animator;
    [SerializeField] private float speed;
    [SerializeField] private float tempSpeed;
    private bool isFlipped;
    public bool isAction;
    public bool isMove;
    [Header("Boss infomation")]
    [SerializeField] private int bossId;
    [SerializeField] private float atkRange;
    [SerializeField] private bool phase2;
    [SerializeField] private bool enraged;
    [SerializeField] private float enragedTime;
    [SerializeField] private int bossMaxHealthPoint;
    [SerializeField] private int bossCurrentHealthPoint;
    [SerializeField] private int bossDefend;
    [SerializeField] private int bossAttackDame;
    [SerializeField] private int tempBossDefend;
    [SerializeField] private int tempBossAttackDame;
    bool isCoolDown;
    // Start is called before the first frame update
    void Start()
    {
        isAction = true; 
        isMove = true;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        StartCoroutine(BossBehaviour());
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            MoveToPlayer();
        }
        else
        {
            speed = 0f;
        }
    }
    private void SetupBossStatus()
    {
        speed = 3f;
        tempSpeed = speed;
        atkRange = 2f;
        phase2 = true;
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
        Attack();
    }
    private void LookAtPlayer()
    {
        if(transform.position.x > playerPos.position.x && isFlipped)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            //transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if(transform.position.x < playerPos.position.x && !isFlipped)
        {
            transform.localScale = new Vector3(1, 1, 1);
            //transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
    public void BossTakeDame(int damage)
    {
        var dameTaken = damage - bossDefend > 0 ? damage - bossDefend : 0;
        if (bossCurrentHealthPoint - dameTaken <= 0)
        {
            if (phase2)
            {
                //load anim angry

                //set current hp return full
                bossCurrentHealthPoint = bossMaxHealthPoint;
                // increase status
                BossEnraged();
            }
            else
            {
                //dead
            }
        }
        else
        {
            bossCurrentHealthPoint -= dameTaken;
        }
    }

    IEnumerator BossEnraged()
    {
        while (true)
        {
            if(enragedTime > 0)
            {
                bossAttackDame = tempBossAttackDame * 3;
                bossDefend = tempBossDefend * 3;
                enragedTime -= 1;
            }
            else if(enragedTime <= 0 && !isCoolDown)
            {
                isCoolDown = true;
                bossAttackDame = tempBossAttackDame * 5;
                bossDefend = tempBossDefend * 5;
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
        if(Vector2.Distance(playerPos.position,rigidbody2D.position) <= atkRange)
        {
            //attack
            Debug.Log("Boss normal attack");
            animator.SetTrigger("isAttack");
            speed = tempSpeed;
        }
    }
    private void UseSkill()
    {
        Debug.Log("Boss use skill");
        isAction = true;
    }
    IEnumerator BossBehaviour()
    {
        while (true)
        {
            // chi thuc hien hanh dong tiep theo khi hanh dong truoc do hoan thanh
            if (isAction)
            {
                isAction = false;
                // neu khoang cach qua xa
                if (Vector2.Distance(playerPos.position, rigidbody2D.position) > 10f)
                {
                    var random = Random.RandomRange(0, 2);
                    if(random % 2 == 0)
                    {
                        speed = 6f;
                        isMove = true;
                    }
                    else
                    {
                        isMove = false;
                        UseSkill();
                    }
                }
                // neu khoang cach gan
                else
                {
                    speed = tempSpeed;
                    isMove = true;
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
