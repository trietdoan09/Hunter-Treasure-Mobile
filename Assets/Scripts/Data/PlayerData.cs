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
    public int playerHealPoint; // máu
    public int playerManaPoint; // mana
    public int playerAttackPoint; // tấn công
    public int playerDefendPoint; // giáp
    public int playerSkillPoint; // điểm kĩ năng
    public int playerStatusPoint; // điểm chỉ số
    public int levelPlayer; // cấp độ nhân vật
    public PlayerData(PlayerManager playerManager)
    {
        playerId = playerManager.id;
        playerHealPoint = playerManager.playerHealPoint;
        playerManaPoint = playerManager.playerManaPoint;
        playerAttackPoint = playerManager.playerAttackPoint;
        playerDefendPoint = playerManager.playerDefendPoint;
        playerSkillPoint = playerManager.playerSkillPoint;
        playerStatusPoint = playerManager.playerStatusPoint;
        levelPlayer = playerManager.levelPlayer;
    }
}
