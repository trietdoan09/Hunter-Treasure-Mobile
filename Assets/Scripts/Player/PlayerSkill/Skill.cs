using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static SkillTree;

public class Skill : MonoBehaviour
{
    public int id;
    public TextMeshProUGUI titleText;
    public int[] connectedUpgrades;
    private GameObject playerManager;
    [SerializeField] private Image image;
    [SerializeField] private Image border;
    public int[] connectedSkills;
    private void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player");
    }
    public void UpdateUI()
    {
        titleText.text = $"{skillTree.skillNames[id]} \n {skillTree.skillLevels[id]} / {skillTree.skillCaps[id]} ";
        border.color = skillTree.skillLevels[id] >= skillTree.skillCaps[id] ? Color.yellow
            : skillTree.skillPoint > 0 ? Color.green : Color.white;
        image.sprite = skillTree.sprites[id];
        foreach(var connected in connectedSkills)
        {
            skillTree.skillList[connected].gameObject.SetActive(skillTree.skillLevels[id] > 0);
            skillTree.connectionList[connected].gameObject.SetActive(skillTree.skillLevels[id] > 0);
        }
    }
    public void BuySkill()
    {
        if(skillTree.skillPoint < 1 || skillTree.skillLevels[id] >= skillTree.skillCaps[id])
        {
            return;
        }
        playerManager.GetComponent<PlayerManager>().playerSkillPoint -= 1;
        skillTree.skillLevels[id]++;
        skillTree.UpdateAllSkillUI();
    }
}
