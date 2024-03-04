using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public static CombatSystem instance;
    public Animator characterAnim;
    public bool isAttack;
    private int timeEndCombo;
    //normal attack
    [SerializeField] private Transform attackPostition;
    [SerializeField] private Vector2 attackRange;
    [SerializeField] private LayerMask enemyLayers;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        characterAnim = GetComponent<Animator>();
        attackRange = new Vector2(1, 0.5f);
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
                Debug.Log("We hit" + enemy.name);
            }
        }
    }
    private void OnDrawGizmos()
    {
        if (attackPostition == null)
            return;
        Gizmos.DrawWireCube(attackPostition.position, attackRange);
    }
}
