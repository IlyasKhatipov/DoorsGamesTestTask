using UnityEngine;

public class AssaultRifle : Weapon
{
    public AssaultRifle(Ammo ammo, GameObject firePoint)
        : base("�������", 1, 1, 1.0f, WeaponType.AssaultRifle, ammo, firePoint)
    {
    }
}