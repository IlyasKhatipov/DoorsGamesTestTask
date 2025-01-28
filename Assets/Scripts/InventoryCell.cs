using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    public Item item;
    public TextMeshProUGUI quantity;
    public TextMeshProUGUI description;
    public TextMeshProUGUI useButtonText;
    public Image Icon;
    public Image popUpIcon; 
    public GameObject popUP;

    private Human _player;
    private ItemType _itemType;

    public void Start() 
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Human>();
        closePopUp();
        if (item != null) 
        {
            _itemType = item.itemType;

            switch (_itemType)
            {
                case ItemType.Ammo:
                    useButtonText.text = "Buy";
                    break;
                case ItemType.Medkit:
                    useButtonText.text = "Heal";
                    break;
                case ItemType.Clothing:
                    useButtonText.text = "Equip";
                    break;
            }
        }
    }

    public void Update()
    {
        if (item != null)
        {
            quantity.text = item.quantity.ToString();

            Transform spriteTransform = item.transform.Find("Sprite");
            if (spriteTransform != null)
            {
                Icon.sprite = spriteTransform.GetComponent<SpriteRenderer>()?.sprite;
                popUpIcon.sprite = spriteTransform.GetComponent<SpriteRenderer>()?.sprite;
            }

            UpdateDescription();
        }
        else
        {
            quantity.text = "";
            description.text = "";
            Icon.sprite = null;
            popUpIcon.sprite = null;
        }
    }

    private void UpdateDescription()
    {
        if (item != null)
        {
            string descriptionText = $"Name: {item.itemName}\n" +
                                     $"Type: {item.itemType}\n" +
                                     $"Weight: {item.weight} кг\n" +
                                     $"Quantity: {item.quantity}/{item.maxStack}";
            
            description.text = descriptionText;
        }
        else
        {
            description.text = "";
        }
    }

    public void useItem() 
    {
        switch (_itemType)
        {
            case ItemType.Ammo:
                Ammo ammo = item.GetComponent<Ammo>();
                if (ammo.ammoType == AmmoType.Pistol) { _player.fillPistolAmmo(); }
                else { _player.fillAssaultRifleAmmo(); }
                break;
            case ItemType.Medkit:
                Medkit medkit = item.GetComponent<Medkit>();
                _player.Heal(medkit.healAmount);
                break;
            case ItemType.Clothing:
                Clothing clothing = item.GetComponent<Clothing>();
                if (clothing != null)
                {
                    if (clothing.clothingType == ClothingType.Head)
                    {
                        _player.setHead(clothing);
                    }
                    else
                    {
                        _player.setTorso(clothing); 
                    }
                }
                else
                {
                    Debug.LogError("Объект item не содержит компонент Clothing!");
                }
                break;
        }
        destroyItem();
    }

    public void destroyItem()
    {
        if (item != null)
        {
            Destroy(item.gameObject);

            item = null;

            quantity.text = "";
            description.text = "";
            Icon.sprite = null;
            popUpIcon.sprite = null;

            Debug.Log("Предмет удален из ячейки.");
        }
        else
        {
            Debug.Log("В ячейке нет предмета для удаления.");
        }
    }

    public void showPopUp()
    {
        if (item != null)
        {
            popUP.SetActive(true);
        }
    }

    public void closePopUp()
    {
        popUP.SetActive(false);
    }
}