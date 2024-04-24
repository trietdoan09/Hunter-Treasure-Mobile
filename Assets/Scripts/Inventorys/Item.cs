using UnityEngine;

[CreateAssetMenu(menuName = "Scriptatle object/Item")]

public class Item : ScriptableObject
{
   
    //[Header("Only Gameplay")]
    //public ItemType type;

    //public Vector2Int range = new Vector2Int(5, 4);

    [Header("Both ")]
    public Sprite image;
    public int id;

    [Header("Only UI")]

    public string itemName, level, types, description;
    public int quantity;

    public bool useItem;
    public bool stackable;

    public int timer;

    [Header("Shop")]
    public int productprice;

    public int value;
}

//public enum ItemType
//{
//   UseItem,
//   NotUseItem
//}

