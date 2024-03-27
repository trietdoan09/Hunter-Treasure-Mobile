using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static SkillTree;

public class SetSkill : MonoBehaviour, IPointerClickHandler
{
    public int setSkillId;
    OpenSkillAndInfomationPlayer openSkill;
    [SerializeField] private Image border;

    public void OnPointerClick(PointerEventData eventData)
    {
        openSkill.id = setSkillId;
    }

    // Start is called before the first frame update
    void Start()
    {
        openSkill = FindObjectOfType<OpenSkillAndInfomationPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(setSkillId == openSkill.id)
        {
            border.color = Color.yellow;
        }
        else
        {
            border.color = Color.white;
        }
    }
}
