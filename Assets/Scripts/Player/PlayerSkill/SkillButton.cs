using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour, IPointerClickHandler
{
    OpenSkillAndInfomationPlayer openSkill;
    [SerializeField] private Image image;
    public int buttonId;
    public int holdSkillId;
    public bool isValid;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(holdSkillId != openSkill.id)
        {
            isValid = Array.Exists(openSkill.buttonHoldSkillId, element => element == openSkill.id); // true: exists
        }
        else
        {
            isValid = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        isValid = true;
        openSkill = FindObjectOfType<OpenSkillAndInfomationPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSkill(); 
    }
    private void ChangeSkill()
    {
        if (!isValid)
        {
            image.sprite = openSkill.images[openSkill.id - 4].sprite;
            holdSkillId = openSkill.id;
            openSkill.buttonHoldSkillId[buttonId] = holdSkillId;
            isValid = true;
        }
    }
    public void GameLoaded()
    {
        holdSkillId = openSkill.buttonHoldSkillId[buttonId];
        if (holdSkillId >= 4)
        {
            image.sprite = openSkill.images[holdSkillId - 4].sprite;
        }
        isValid = true;
    }
}
