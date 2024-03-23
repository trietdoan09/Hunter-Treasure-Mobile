using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpenSkillAndInfomationPlayer : MonoBehaviour
{
    [SerializeField] private GameObject uiCanvas;
    [SerializeField] private GameObject uiSkill;
    [SerializeField] private GameObject uiInfomation;
    [SerializeField] private GameObject uiCloseButton;
    [SerializeField] private GameObject chosenInfo;
    [SerializeField] private GameObject chosenSkill;
    private bool isShowCanvas;

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

    private GameObject playerManager;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player");
        uiCanvas.SetActive(false);
        uiSkill.SetActive(false);
        chosenSkill.SetActive(false);
        uiInfomation.SetActive(false);
        chosenInfo.SetActive(false);
        sliderHP.maxValue = playerManager.GetComponent<PlayerManager>().playerMaxHealPoint;
        sliderMP.maxValue = playerManager.GetComponent<PlayerManager>().playerMaxManaPoint;
        sliderExp.maxValue = playerManager.GetComponent<PlayerManager>().maxExp;

        sliderUiHP.maxValue = playerManager.GetComponent<PlayerManager>().playerMaxHealPoint;
        sliderUiMP.maxValue = playerManager.GetComponent<PlayerManager>().playerMaxManaPoint;
        StartCoroutine(showHpBar());
        StartCoroutine(showMpBar());
        StartCoroutine(showExpBar());
    }

    // Update is called once per frame
    void Update()
    {
        ShowUiStatus();
    }
    
    private IEnumerator showHpBar()
    {
        while (true)
        {
            sliderHP.maxValue = playerManager.GetComponent<PlayerManager>().playerMaxHealPoint;
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
