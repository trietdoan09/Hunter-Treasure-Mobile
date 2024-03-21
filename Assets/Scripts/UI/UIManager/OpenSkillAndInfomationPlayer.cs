using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSkillAndInfomationPlayer : MonoBehaviour
{
    [SerializeField] private GameObject uiCanvas;
    [SerializeField] private GameObject uiSkill;
    [SerializeField] private GameObject uiInfomation;
    [SerializeField] private GameObject uiCloseButton;
    [SerializeField] private GameObject chosenInfo;
    [SerializeField] private GameObject chosenSkill;
    private bool isShowCanvas;

    // Start is called before the first frame update
    void Start()
    {
        uiCanvas.SetActive(false);
        uiSkill.SetActive(false);
        chosenSkill.SetActive(false);
        uiInfomation.SetActive(false);
        chosenInfo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PlayerSkillClick()
    {
        if (!isShowCanvas)
        {
            isShowCanvas = true;
            uiCanvas.SetActive(isShowCanvas);
            uiSkill.SetActive(true);
            chosenSkill.SetActive(true);
            uiInfomation.SetActive(false);
            chosenInfo.SetActive(false);
        }
        else
        {
            uiSkill.SetActive(true);
            chosenSkill.SetActive(true);
            uiInfomation.SetActive(false);
            chosenInfo.SetActive(false);
        }
    }

    public void PlayerInfoClick()
    {
        if (!isShowCanvas)
        {
            isShowCanvas = true;
            uiCanvas.SetActive(isShowCanvas);
            uiSkill.SetActive(false);
            chosenSkill.SetActive(false);
            uiInfomation.SetActive(true);
            chosenInfo.SetActive(true);
        }
        else
        {
            uiSkill.SetActive(false);
            chosenSkill.SetActive(false);
            uiInfomation.SetActive(true);
            chosenInfo.SetActive(true);
        }
    }

    public void CloseButtonClick()
    {
        isShowCanvas = false;
        uiCanvas.SetActive(isShowCanvas);
        uiSkill.SetActive(false);
        chosenSkill.SetActive(false);
        uiInfomation.SetActive(false);
        chosenInfo.SetActive(false);
    }
}
