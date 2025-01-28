using UnityEngine;

public class Pistol : Weapon
{
    public Pistol(Ammo ammo, GameObject firePoint)
        : base("Пистолет", 1, 1, 1.0f, WeaponType.Pistol, ammo, firePoint) 
    {
    }
}