using UnityEngine;

[System.Serializable]
public class Clothing : Item
{
    public ClothingType clothingType;
    public int defense;

    public Clothing(string name, int quantity, int maxStack, float weight, ClothingType clothingType, int defense)
        : base(name, quantity, maxStack, weight, ItemType.Clothing)
    {
        this.clothingType = clothingType;
        this.defense = defense;
    }
}