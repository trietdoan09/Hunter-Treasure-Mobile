using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerUseSkill : MonoBehaviour, IPointerClickHandler
{
    public int buttonId;
    public int skillid;
    OpenSkillAndInfomationPlayer openSkill;
    CombatSystem combatSystem;

    public void OnPointerClick(PointerEventData eventData)
    {
        combatSystem.idSkill = skillid;
        combatSystem.buttonCallUseSkill = buttonId;
        combatSystem.UseSkill();
    }

    // Start is called before the first frame update
    void Start()
    {
        openSkill = FindObjectOfType<OpenSkillAndInfomationPlayer>();
        combatSystem = FindObjectOfType<CombatSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        skillid = openSkill.buttonHoldSkillId[buttonId];
    }
    
}
