using UnityEngine;

[CreateAssetMenu(menuName = "Scriptatle object/ItemShop")]

public class ItemShop : ScriptableObject
{

    public Sprite image;
    public int id;

    [Header("Only UI")]

    public string itemName, level, types, description;
    public int quantity;

    [Header("Shop")]
    public int productprice;

    public int value;
}
