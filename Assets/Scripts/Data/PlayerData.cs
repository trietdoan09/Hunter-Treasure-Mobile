using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PlayerData
{
    public int characterID;

    public PlayerData (CreateCharacter createCharacter)
    {
        characterID = createCharacter.characterId;
    }
    public int playerId;
    public int playerMaxHealPoint; // máu tối đa
    public int playerCurrentHealPoint; // máu hiện tại
    public int playerMaxManaPoint; // mana tối đa
    public int playerCurrentManaPoint; //mana hiện tại
    public int playerAttackPoint; // tấn công
    public int playerDefendPoint; // giáp
    public int playerSkillPoint; // điểm kĩ năng
    public int playerStatusPoint; // điểm chỉ số
    public int levelPlayer; // cấp độ nhân vật
    public float currentExp; // exp hiện tại
    public float maxExp; //exp tối đa
    public PlayerData(PlayerManager playerManager)
    {
        playerId = playerManager.id;
        playerMaxHealPoint = playerManager.playerMaxHealPoint;
        playerCurrentHealPoint = playerManager.playerCurrentHealPoint;
        playerMaxManaPoint = playerManager.playerMaxManaPoint;
        playerCurrentManaPoint = playerManager.playerCurrentManaPoint;
        playerAttackPoint = playerManager.playerAttackPoint;
        playerDefendPoint = playerManager.playerDefendPoint;
        playerSkillPoint = playerManager.playerSkillPoint;
        playerStatusPoint = playerManager.playerStatusPoint;
        levelPlayer = playerManager.levelPlayer;
        currentExp = playerManager.currentExp;
        maxExp = playerManager.maxExp;
    }
}
