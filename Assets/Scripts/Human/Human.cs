using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Human : MonoBehaviour
{
    public Pistol currentPistol;
    public AssaultRifle currentAssaultRifle;
    public GameObject weaponPoint;
    public int HP = 100;
    public int defense = 0;
    public Clothing _head;
    public Clothing _torso;
    public Image _headIcon;
    public TextMeshProUGUI _headText;
    public TextMeshProUGUI _hpText;
    public Image _torsoIcon;
    public TextMeshProUGUI _torsoText;


    private Weapon currentWeapon;

    public void Update() 
    {
        if (_hpText != null) 
        {
            _hpText.text = HP.ToString();
        }
        
    }

    public void setPistol()
    {
        if (currentWeapon != null) { Destroy(currentWeapon.gameObject); }
        Weapon newPistol = Instantiate(currentPistol, weaponPoint.transform.position, weaponPoint.transform.rotation);
        newPistol.transform.localScale = new Vector3(4.0f, 4.0f, 1.0f);
        currentWeapon = newPistol;
    }

    public void setAssaultRifle()
    {
        if (currentWeapon != null) { Destroy(currentWeapon.gameObject); }
        Weapon newPistol = Instantiate(currentAssaultRifle, weaponPoint.transform.position, weaponPoint.transform.rotation);
        newPistol.transform.localScale = new Vector3(4.0f, 4.0f, 1.0f);
        currentWeapon = newPistol;
    }

    public void fillPistolAmmo() 
    {
        if (currentPistol != null) 
        {
            currentPistol.ammo.quantity = 50;
        }
    }

    public void Heal(int amount) 
    {
        if (HP < 100) 
        { 
            HP += amount;
            if (HP > 100) { HP = 100; }
        }
    }

    public void fillAssaultRifleAmmo() 
    {
        if (currentAssaultRifle != null) 
        {
            currentAssaultRifle.ammo.quantity = 100;
        }
    }

    public void setHead(Clothing head) 
    {
        _head = head;
        SpriteRenderer headSprite = head.transform.Find("Sprite").GetComponent<SpriteRenderer>();
        _headIcon.sprite = headSprite.sprite;
        _headText.text = head.defense.ToString();
        defense += head.defense;
    }

    public void setTorso(Clothing torso)
    {
        _torso = torso;
        SpriteRenderer torsoSprite = torso.transform.Find("Sprite").GetComponent<SpriteRenderer>();
        _torsoIcon.sprite = torsoSprite.sprite;
        _torsoText.text = torso.defense.ToString();
        defense += torso.defense;
    }

    public void Shoot()
    {
        currentWeapon.Shoot();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ammo")) 
        {
            Ammo ammo = other.gameObject.GetComponent<Ammo>();
            TakeDamage(ammo.damage);
        }
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        Debug.Log($"Игрок получил {damage} урона. Осталось HP: {HP}");

        if (HP <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        this.gameObject.SetActive(false);
        Debug.Log("Игрок умер!");
    }
}