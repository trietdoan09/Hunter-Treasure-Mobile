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
        ActiveSkill();
        skillTree.UpdateAllSkillUI();
    }
    private void ActiveSkill() 
    {
        switch (id)
        {
            case 0:
                {
                    playerManager.GetComponent<PlayerManager>().playerMaxManaPoint += 100;
                    playerManager.GetComponent<PlayerManager>().playerMaxHealPoint += 50;
                    playerManager.GetComponent<PlayerManager>().playerDefendPoint += 10;
                    playerManager.GetComponent<PlayerManager>().playerAttackPoint += 15;
                    break;
                }
            case 1:
                {
                    playerManager.GetComponent<PlayerManager>().playerMaxManaPoint += 20;
                    break;
                }
            case 2:
                {
                    playerManager.GetComponent<PlayerManager>().playerMaxManaPoint += 50;
                    playerManager.GetComponent<PlayerManager>().playerAttackPoint += 10;
                    break;
                }
            case 3:
                {
                    playerManager.GetComponent<PlayerManager>().playerMaxManaPoint += 100;
                    playerManager.GetComponent<PlayerManager>().playerAttackPoint += 30;
                    break;
                }
            case 4:
                {
                    skillTree.skillDamage[0] += 80;
                    break;
                }
            case 5:
                {
                    skillTree.skillDamage[1] += 75;
                    break;
                }
            case 6:
                {
                    skillTree.skillDamage[2] += 70;
                    break;
                }
            case 7:
                {
                    skillTree.manaDecrease[0] -= 35;
                    skillTree.tempDameInscrease[0] += 10;
                    break;
                }
            case 8:
                {
                    skillTree.manaDecrease[1] -= 25;
                    skillTree.tempDameInscrease[1] += 50;
                    break;
                }
            case 9:
                {
                    skillTree.tempDameInscrease[2] += 200;
                    break;
                }

            default: break;
        }
    }
}
