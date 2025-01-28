using UnityEngine;

[System.Serializable]
public class Weapon : Item
{
    public WeaponType weaponType;
    public Ammo ammo;
    public GameObject firePoint;
    public float ammoSpeed;

    public Weapon(string name, int quantity, int maxStack, float weight, WeaponType weaponType, Ammo ammo, GameObject firePoint)
        : base(name, quantity, maxStack, weight, ItemType.Weapon)
    {
        this.weaponType = weaponType;
        this.ammo = ammo;
        this.firePoint = firePoint;
    }

    public void Shoot()
    {
        if (ammo.quantity > 0)
        {
            Ammo bullet = Instantiate(ammo, firePoint.transform.position, firePoint.transform.rotation);
            bullet.transform.localScale = new Vector3(4.0f, 4.0f, 1.0f);

            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            float bulletSpeed = ammoSpeed; 
            bulletRb.linearVelocity = firePoint.transform.right * bulletSpeed;
           

            // ��������� ���������� ��������
            ammo.quantity--;

            Debug.Log($"�������! �������� ��������: {ammo.quantity}");
        }
        else
        {
            Debug.Log("��� ��������!");
        }
    }
}