using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    #region Save character id
    public static void SaveCharacterID(CreateCharacter createCharacter)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/characterId.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(createCharacter);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static PlayerData LoadCharacterID()
    {
        string path = Application.persistentDataPath + "/characterId.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData character = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return character;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
    #endregion

}
