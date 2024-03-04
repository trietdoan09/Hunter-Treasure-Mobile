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
    public int playerHealPoint; // máu
    public int playerManaPoint; // mana
    public int playerAttackPoint; // tấn công
    public int playerDefendPoint; // giáp
    public int playerSkillPoint; // điểm kĩ năng
    public int playerStatusPoint; // điểm chỉ số
    public int levelPlayer; // cấp độ nhân vật


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
        characters = characterDatabase.GetCharacters(id);
        //LoadCharacterId();
        SpawnPlayer();
        InitPlayerStatus();
    }

    // Update is called once per frame
    void Update()
    {
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
        playerHealPoint = data.playerHealPoint;
        playerManaPoint = data.playerManaPoint;
        playerAttackPoint = data.playerAttackPoint;
        playerDefendPoint = data.playerDefendPoint;
        playerSkillPoint = data.playerSkillPoint;
        playerStatusPoint = data.playerStatusPoint;
        levelPlayer = data.levelPlayer;
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
                    playerHealPoint = 80;
                    playerManaPoint = 100;
                    playerAttackPoint = 170;
                    playerDefendPoint = 50;
                    break;
                }
            case CharacterClass.Swordman:
                {
                    playerHealPoint = 100;
                    playerManaPoint = 100;
                    playerAttackPoint = 100;
                    playerDefendPoint = 100;
                    break;
                }
            case CharacterClass.Wizard:
                {
                    playerHealPoint = 80;
                    playerManaPoint = 170;
                    playerAttackPoint = 100;
                    playerDefendPoint = 50;
                    break;
                }
            case CharacterClass.Knight:
                {
                    playerHealPoint = 150;
                    playerManaPoint = 110;
                    playerAttackPoint = 40;
                    playerDefendPoint = 100;
                    break;
                }
            default:break;
        }
        playerSkillPoint = 0;
        playerStatusPoint = 0;
    }
}
