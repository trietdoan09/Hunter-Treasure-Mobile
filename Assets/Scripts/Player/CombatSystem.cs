using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    private Animator animator;
    public int totalCombo;
    private bool isAttack;
    private int timeEndCombo;
    // Start is called before the first frame update
    void Start()
    {
        totalCombo = -1;
        animator = GetComponent<Animator>();
        StartCoroutine(EndCombo());
    }

    // Update is called once per frame
    void Update()
    {
        NormalAttackAnimation();
        FinishComboNormalAttack();
    }
    public void NormalAttackCombo()
    {
        isAttack = true;
        if (totalCombo < 3)
        {
            totalCombo++;
            timeEndCombo = 1;
        }
    }
    IEnumerator EndCombo()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            timeEndCombo -= 1;
            yield return null;
        }
    }
    private void FinishComboNormalAttack()
    {
        if (timeEndCombo <= 0)
        {
            totalCombo = -1;
            isAttack = false;
        }
    }
    private void NormalAttackAnimation()
    {
        if (isAttack)
        {
            animator.SetTrigger("Combo" + totalCombo);
        }
    }
}
