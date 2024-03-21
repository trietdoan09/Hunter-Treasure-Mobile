using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public int id;
    public string nameCharacter;
    [SerializeField] private CharacterGender genderCharacter;
    [SerializeField] private CharacterClass characterClass;
    [SerializeField] private CharacterDatabase characterDatabase;
    private Animator animator;
    Characters characters;
    //Player index
    [Header("Player infomation")]
    public int playerMaxHealPoint; // máu tối đa
    public int playerCurrentHealPoint; // máu hiện tại
    public int playerMaxManaPoint; // mana tối đa
    public int playerCurrentManaPoint;
    public int playerAttackPoint; // tấn công
    public int playerDefendPoint; // giáp
    public int playerSkillPoint; // điểm kĩ năng
    public int playerStatusPoint; // điểm chỉ số
    public int levelPlayer; // cấp độ nhân vật
    public float currentExp; // kinh nghiệm hiện tại của nhân vật
    public float maxExp; //kinh nghiệm tối đa cần để tăng cấp


    // Start is called before the first frame update
    private void Awake()
    {
        // Get the Animator component attached to the game object
        instance = this;
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        id = 7;
        //LoadCharacterId();
        characters = characterDatabase.GetCharacters(id);
        SpawnPlayer();
        InitPlayerStatus();
    }

    // Update is called once per frame
    void Update()
    {
        LevelUp();
        if (Input.GetKeyDown(KeyCode.F8))
        {
            LoadSaveSlot();
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            SaveSlot();
        }
    }
    public void LoadCharacterId()
    {
        PlayerData data = SaveSystem.LoadCharacterID();
        id = data.characterID;
    }
    public void LoadSaveSlot()
    {
        PlayerData data = SaveSystem.LoadGame();
        id = data.playerId;
        playerMaxHealPoint = data.playerMaxHealPoint;
        playerCurrentHealPoint = data.playerCurrentHealPoint;
        playerMaxManaPoint = data.playerMaxManaPoint;
        playerCurrentManaPoint = data.playerCurrentManaPoint;
        playerAttackPoint = data.playerAttackPoint;
        playerDefendPoint = data.playerDefendPoint;
        playerSkillPoint = data.playerSkillPoint;
        playerStatusPoint = data.playerStatusPoint;
        levelPlayer = data.levelPlayer;
        currentExp = data.currentExp;
        maxExp = data.maxExp;
        Debug.Log("Load save complete");
    }
    public void SaveSlot()
    {
        SaveSystem.SaveGame(this);
        Debug.Log("Game saved");
    }
    private void SpawnPlayer()
    {
        //var Player = Instantiate(spawnPlayer[id]);
        //Player.transform.position = gameObject.transform.position;
        gameObject.GetComponent<SpriteRenderer>().sprite = characters.sprite;
        nameCharacter = characters.name;
        genderCharacter = characters.gender;
        characterClass = characters.characterClass;
        animator.runtimeAnimatorController = characters.animatorController;
    }
    private void InitPlayerStatus()
    {
        levelPlayer = 1;
        switch (characterClass)
        {
            case CharacterClass.Archer:
                {
                    playerMaxHealPoint = 80;
                    playerMaxManaPoint = 100;
                    playerAttackPoint = 170;
                    playerDefendPoint = 50;
                    break;
                }
            case CharacterClass.Swordman:
                {
                    playerMaxHealPoint = 100;
                    playerMaxManaPoint = 100;
                    playerAttackPoint = 100;
                    playerDefendPoint = 100;
                    break;
                }
            case CharacterClass.Wizard:
                {
                    playerMaxHealPoint = 80;
                    playerMaxManaPoint = 170;
                    playerAttackPoint = 100;
                    playerDefendPoint = 50;
                    break;
                }
            case CharacterClass.Knight:
                {
                    playerMaxHealPoint = 150;
                    playerMaxManaPoint = 110;
                    playerAttackPoint = 40;
                    playerDefendPoint = 100;
                    break;
                }
            default:break;
        }
        playerCurrentHealPoint = playerMaxHealPoint;
        playerCurrentManaPoint = playerMaxManaPoint;
        playerSkillPoint = 0;
        playerStatusPoint = 0;
        currentExp = 0;
        maxExp = 500;
    }

    public void PlayerTakeDame(int damage)
    {
        int damagaTaken = damage - playerDefendPoint;
        playerCurrentHealPoint -= damagaTaken > 0 ? damagaTaken : 0;
        if(playerCurrentHealPoint < 0)
        {
            //player died
        }
    }

    public void PlayerTakeExp(int expReceive)
    {
        currentExp += expReceive;
        
    }
    private void LevelUp()
    {
        if (currentExp >= maxExp)
        {
            levelPlayer++;
            playerSkillPoint++;
            playerStatusPoint += 2;
            currentExp = currentExp - maxExp;
            maxExp = maxExp + (maxExp / 2);
        }
    }
}
