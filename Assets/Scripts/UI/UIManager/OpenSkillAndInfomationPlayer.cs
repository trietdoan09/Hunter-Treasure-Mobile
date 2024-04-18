using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static SkillTree;

public class OpenSkillAndInfomationPlayer : MonoBehaviour
{
    [SerializeField] private GameObject uiCanvas;
    [SerializeField] private List<GameObject> uiPlayerInfo;
    [SerializeField] private List<GameObject> uiChosenButton;
    [SerializeField] private GameObject uiCloseButton;

    [Header("Hien trang thai len tab info ui")]
    [SerializeField] private TextMeshProUGUI textHP;
    [SerializeField] private TextMeshProUGUI textMP;
    [SerializeField] private TextMeshProUGUI textATK;
    [SerializeField] private TextMeshProUGUI textDEF;
    [SerializeField] private TextMeshProUGUI textLevel;
    [SerializeField] private TextMeshProUGUI textCurrentStatusPoint;
    [SerializeField] private Slider sliderHP;
    [SerializeField] private Slider sliderMP;
    [SerializeField] private Slider sliderExp;
    
    [Header("Hien trang thai len ui")]
    [SerializeField] private Slider sliderUiHP;
    [SerializeField] private Slider sliderUiMP;
    [SerializeField] private TextMeshProUGUI textUiHp;
    [SerializeField] private TextMeshProUGUI textUiMp;

    [Header("Chon ky nang")]
    public int id;
    public GameObject skillHolder;
    public GameObject buttonHolder;
    public List<TextMeshProUGUI> titleText;
    public List<SetSkill> skillActive;
    public List<SkillButton> skillButtons;
    public List<Image> images;
    [SerializeField] private List<Image> border;
    public int[] buttonHoldSkillId;

    private GameObject playerManager;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player");
        uiCanvas.SetActive(false);
        foreach(var uilayer in uiPlayerInfo)
        {
            uilayer.SetActive(false);
        }
        foreach(var uiChosen in uiChosenButton)
        {
            uiChosen.SetActive(false);
        }
        sliderHP.maxValue = playerManager.GetComponent<PlayerManager>().playerMaxHealPoint;
        sliderMP.maxValue = playerManager.GetComponent<PlayerManager>().playerMaxManaPoint;
        sliderExp.maxValue = playerManager.GetComponent<PlayerManager>().maxExp;

        sliderUiHP.maxValue = playerManager.GetComponent<PlayerManager>().playerMaxHealPoint;
        sliderUiMP.maxValue = playerManager.GetComponent<PlayerManager>().playerMaxManaPoint;
        StartCoroutine(showHpBar());
        StartCoroutine(showMpBar());
        StartCoroutine(showExpBar());
        foreach(var setSkill in skillHolder.GetComponentsInChildren<SetSkill>())
        {
            skillActive.Add(setSkill);
        }
        for (var i = 0; i < skillActive.Count; i++)
        {
            skillActive[i].setSkillId = i + 4;
        }
        foreach(var button in buttonHolder.GetComponentsInChildren<SkillButton>())
        {
            skillButtons.Add(button);
        }
        for (var i = 0; i < skillButtons.Count; i++)
        {
            skillButtons[i].buttonId = i;
        }
        buttonHoldSkillId = new int[skillButtons.Count];
;    }

    // Update is called once per frame
    void Update()
    {
        ShowUiStatus();
        showSkillHaveLearned();
    }
    
    private IEnumerator showHpBar()
    {
        while (true)
        {
            sliderHP.maxValue = playerManager.GetComponent<PlayerManager>().playerMaxHealPoint;
            sliderUiHP.maxValue = playerManager.GetComponent<PlayerManager>().playerMaxHealPoint;
            yield return new WaitForSeconds(0.01f);
            if(sliderHP.value != playerManager.GetComponent<PlayerManager>().playerCurrentHealPoint)
            {
                sliderHP.value += (sliderHP.value - playerManager.GetComponent<PlayerManager>().playerCurrentHealPoint) < 0 ? 1 : -1;
                sliderUiHP.value += (sliderHP.value - playerManager.GetComponent<PlayerManager>().playerCurrentHealPoint) < 0 ? 1 : -1;
            }
            yield return null;
        }
    }
    private IEnumerator showMpBar()
    {
        while (true)
        {
            sliderMP.maxValue = playerManager.GetComponent<PlayerManager>().playerMaxManaPoint;
            sliderUiMP.maxValue = playerManager.GetComponent<PlayerManager>().playerMaxManaPoint;
            yield return new WaitForSeconds(0.01f);
            if(sliderMP.value != playerManager.GetComponent<PlayerManager>().playerCurrentManaPoint)
            {
                sliderMP.value += (sliderMP.value - playerManager.GetComponent<PlayerManager>().playerCurrentManaPoint) < 0 ? 1 : -1;
                sliderUiMP.value += (sliderMP.value - playerManager.GetComponent<PlayerManager>().playerCurrentManaPoint) < 0 ? 1 : -1;
            }
            yield return null;
        }
    }
    private IEnumerator showExpBar()
    {
        while (true)
        {
            sliderExp.maxValue = playerManager.GetComponent<PlayerManager>().maxExp;
            yield return new WaitForSeconds(0.001f);
            if(sliderExp.value != playerManager.GetComponent<PlayerManager>().currentExp)
            {
                sliderExp.value += (sliderExp.value - playerManager.GetComponent<PlayerManager>().currentExp) < 0 ? 1 : -1;
            }
            yield return null;
        }
    }
    
    private void ShowUiStatus()
    {
        textHP.text = $"HP: " + playerManager.GetComponent<PlayerManager>().playerCurrentHealPoint.ToString() + " / " + playerManager.GetComponent<PlayerManager>().playerMaxHealPoint.ToString();
        textMP.text = $"MP: " + playerManager.GetComponent<PlayerManager>().playerCurrentManaPoint.ToString() + " / " + playerManager.GetComponent<PlayerManager>().playerMaxManaPoint.ToString();
        textUiHp.text = $"" + playerManager.GetComponent<PlayerManager>().playerCurrentHealPoint.ToString();
        textUiMp.text = $"" + playerManager.GetComponent<PlayerManager>().playerCurrentManaPoint.ToString();
        textATK.text = $"ATK: " + playerManager.GetComponent<PlayerManager>().playerAttackPoint.ToString();
        textDEF.text = $"DEF: " + playerManager.GetComponent<PlayerManager>().playerDefendPoint.ToString();
        textLevel.text = $"Level: " + playerManager.GetComponent<PlayerManager>().levelPlayer.ToString();
        textCurrentStatusPoint.text = $"Diem hien co: " + playerManager.GetComponent<PlayerManager>().playerStatusPoint.ToString();
    }
    public void PlayerSkillClick()
    {
        uiCanvas.SetActive(true);
        foreach (var uilayer in uiPlayerInfo)
        {
            uilayer.SetActive(false);
        }
        uiPlayerInfo[1].SetActive(true);
        foreach (var uiChosen in uiChosenButton)
        {
            uiChosen.SetActive(false);
        }
        uiChosenButton[1].SetActive(true);
    }

    public void PlayerInfoClick()
    {
        uiCanvas.SetActive(true);
        foreach (var uilayer in uiPlayerInfo)
        {
            uilayer.SetActive(false);
        }
        uiPlayerInfo[0].SetActive(true);
        foreach (var uiChosen in uiChosenButton)
        {
            uiChosen.SetActive(false);
        }
        uiChosenButton[0].SetActive(true);
    }
    public void SetSkillClick()
    {
        uiCanvas.SetActive(true);
        foreach (var uilayer in uiPlayerInfo)
        {
            uilayer.SetActive(false);
        }
        uiPlayerInfo[2].SetActive(true);
        foreach (var uiChosen in uiChosenButton)
        {
            uiChosen.SetActive(false);
        }
        uiChosenButton[2].SetActive(true);
    }

    public void CloseButtonClick()
    {
        uiCanvas.SetActive(false);
        foreach (var uilayer in uiPlayerInfo)
        {
            uilayer.SetActive(false);
        }
        foreach (var uiChosen in uiChosenButton)
        {
            uiChosen.SetActive(false);
        }
    }
    private void showSkillHaveLearned()
    {
        for (var i = 0; i < skillActive.Count; i++)
        {
            skillActive[i].gameObject.SetActive(skillTree.skillLevels[i + 4] > 0);
            titleText[i].text = $"{skillTree.skillNames[i + 4]} \n {skillTree.skillLevels[i + 4]} / {skillTree.skillCaps[i + 4]} ";
            images[i].sprite = skillTree.sprites[i + 4];
        }
    }
}
