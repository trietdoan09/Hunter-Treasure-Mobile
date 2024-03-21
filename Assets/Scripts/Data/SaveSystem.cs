using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
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
    #region save game
    public static void SaveGame(PlayerManager playerManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/SaveSlot1.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(playerManager);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static PlayerData LoadGame()
    {
        string path = Application.persistentDataPath + "/SaveSlot1.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData saveData = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return saveData;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
    #endregion

    #region Save UI
    public static void SaveInventory(InventoryManager inventoryManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/SaveUI.data";
        Debug.Log(path);
        FileStream stream = new FileStream(path, FileMode.Create);

        UIData data = new UIData(inventoryManager);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static UIData LoadInventory()
    {
        string path = Application.persistentDataPath + "/SaveUI.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            UIData saveData = formatter.Deserialize(stream) as UIData;
            stream.Close();

            return saveData;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
    #endregion

   
}
