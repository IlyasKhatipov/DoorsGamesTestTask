using UnityEngine;

[System.Serializable]
public class Medkit : Item
{
    public int healAmount;

    public Medkit(string name, int quantity, int maxStack, float weight, int healAmount)
        : base(name, quantity, maxStack, weight, ItemType.Medkit)
    {
        this.healAmount = healAmount;
    }
}