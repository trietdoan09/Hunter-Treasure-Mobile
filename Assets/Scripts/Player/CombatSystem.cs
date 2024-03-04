using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public Animator characterAnim;
    public int totalCombo;
    public bool isAttack;
    private int timeEndCombo;
    public static CombatSystem instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        totalCombo = 0;
        characterAnim = GetComponent<Animator>();
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
            totalCombo += 1;
        }
    }
}
