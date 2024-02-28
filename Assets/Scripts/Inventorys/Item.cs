using UnityEngine;

[CreateAssetMenu(menuName = "Scriptatle object/Item")]

public class Item : ScriptableObject
{
   
    //[Header("Only Gameplay")]
    //public ItemType type;

    //public Vector2Int range = new Vector2Int(5, 4);

    [Header("Both ")]
    public Sprite image;


    [Header("Only UI")]
    public bool stackable = true;

    public string itemName, level, types, description;

    public bool useItem;

    [Header("Shop")]
    public int productprice;

}

//public enum ItemType
//{
//   UseItem,
//   NotUseItem
//}

