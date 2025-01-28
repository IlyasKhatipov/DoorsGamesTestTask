using UnityEngine;

[System.Serializable]
public class Ammo : Item
{
    public AmmoType ammoType;
    public int damage;

    public Ammo(string name, int quantity, int maxStack, float weight, AmmoType ammoType, int damage)
        : base(name, quantity, maxStack, weight, ItemType.Ammo)
    {
        this.ammoType = ammoType;
        this.damage = damage;
    }
}