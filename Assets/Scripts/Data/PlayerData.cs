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
}
