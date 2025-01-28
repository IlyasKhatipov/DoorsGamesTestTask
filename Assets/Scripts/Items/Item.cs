using UnityEngine;

[System.Serializable]
public class Item : MonoBehaviour
{
    public string itemName;
    public int quantity;
    public int maxStack;
    public float weight;
    public ItemType itemType;

    public Item(string name, int quantity, int maxStack, float weight, ItemType itemType)
    {
        this.itemName = name;
        this.quantity = quantity;
        this.maxStack = maxStack;
        this.weight = weight;
        this.itemType = itemType;
    }
}