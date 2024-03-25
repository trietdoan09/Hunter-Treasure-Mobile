using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    public static SkillTree skillTree;
    private void Awake() => skillTree = this;
    [Header("Skill info")]
    public int[] skillLevels; // tổng số skill có thể kích hoạt
    public int[] skillCaps; // max level mỗi skill
    public string[] skillNames; //tên skill
    public string[] skillDescriptions; // mô tả skill
    public int[] skillCooldown; // thoi gian hoi chieu
    public bool[] isActiveSkill; // skill active hay passive
    [Header("Skill manager")]
    public List<Skill> skillList;
    public GameObject skillHolder;
    public int[] skillDamage;
    public int[] manaDecrease;
    public int[] tempDameInscrease;
    [Header("Connection manager")]
    public List<GameObject> connectionList;
    public GameObject connectionHolder;
    PlayerManager playerManager;
    public Sprite[] sprites;
    public int skillPoint;
    private void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        skillLevels = new int[10];
        skillCaps = new[] { 1, 1, 1, 1, 3, 5, 9, 3, 2, 1 };
        skillNames = new[] { "Skill 1", "Skill 2", "Skill 2 Evolved", "Skill 2 Evolved Upgrade", 
            "Skill 3", "Skill 3 Evolved", "Skill 3 Evolved Upgrade", "Skill 4", "Skill 4 Evolved", "Skill 4 Evolved Upgrade" };
        skillDescriptions = new[]
        {
            "Kỹ năng đầu tiên cần mở khóa nếu muốn mở khóa các chiêu khác",
            "Tăng một ít mana",
            "Tăng nhiều mana và một ít tấn công",
            "Tăng nhiều mana và nhiều tấn công",
            "Kỹ năng gây một lượng nhỏ sát thương tấn công tầm xa",
            "Kỹ năng gây một lượng vừa sát thương tấn công tầm xa",
            "Kỹ năng gây lượng lớn sát thương tấn công tầm xa",
            "Tiêu hao lượng lớn mana tăng một ít tấn công",
            "Tiêu hao lượng vừa mana tăng lượng vừa tấn công",
            "Tiêu hao một ít mana tăng lượng lớn tấn công tấn công",
        };
        isActiveSkill = new[] { false, false, false, false, true, true, true, true, true, true };
        skillCooldown = new[] { 0, 0, 0, 0, 10, 20, 40, 10, 20, 30 };
        skillDamage = new int[3] { 0, 0, 0 };
        manaDecrease = new int[3] { 500, 250, 100 };
        tempDameInscrease = new int[3] { 0, 0, 0 };
        foreach (var skill in skillHolder.GetComponentsInChildren<Skill>())
        {
            skillList.Add(skill);
        }
        foreach(var connector in connectionHolder.GetComponentsInChildren<RectTransform>())
        {
            connectionList.Add(connector.gameObject);
        }
        for(var i = 0; i < skillList.Count; i++)
        {
            skillList[i].id = i;
        }
        skillList[0].connectedSkills = new[] { 1, 4, 7 };
        skillList[1].connectedSkills = new[] { 2 };
        skillList[2].connectedSkills = new[] { 3 };
        skillList[4].connectedSkills = new[] { 5 };
        skillList[5].connectedSkills = new[] { 6 };
        skillList[7].connectedSkills = new[] { 8 };
        skillList[8].connectedSkills = new[] { 9 };
    }
    private void Update()
    {
        skillPoint = playerManager.GetComponent<PlayerManager>().playerSkillPoint;
        UpdateAllSkillUI();
    }
    public void UpdateAllSkillUI()
    {
        foreach(var skill in skillList)
        {
            skill.UpdateUI();
        }
    }
}
