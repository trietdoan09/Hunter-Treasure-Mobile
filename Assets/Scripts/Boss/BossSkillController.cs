using System.Collections;
using UnityEngine;

public class BossSkillController : MonoBehaviour
{
    BossController bossController;
    PlayerManager playerManager;
    Animator animator;
    public int idSkill;
    [SerializeField] private float speed;
    public float direction;
    private bool autoDestroy;
    // Start is called before the first frame update
    void Start()
    {
        autoDestroy = true;
        bossController = GameObject.FindObjectOfType<BossController>();
        playerManager = GameObject.FindObjectOfType<PlayerManager>();
        animator = GetComponent<Animator>();
        StartCoroutine(AutoDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        if (idSkill < 2)
        {
            transform.position += new Vector3(speed * direction * Time.deltaTime, 0, 0);
        }
    }

    IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(2f);
        if (autoDestroy)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            speed = 0.1f;
            autoDestroy = false;
            Debug.Log("Skill " + idSkill + " give dame");
            var skillDamage = bossController.bossAttackDame * (idSkill + 1);
            playerManager.PlayerTakeDame(skillDamage);
            if (idSkill < 2)
            {
                animator.SetTrigger("isExplore");
                Destroy(gameObject, 0.5f);
            }
            else
            {
                Destroy(gameObject, 0.5f);
            }
        }
    }
}
