using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    Button equipButton;
    public Image selectedImageUI;

    [HideInInspector]
    public Item item;

    private void Awake()
    {
        equipButton = icon.GetComponent<Button>();
    }

    private void Start()
    {
        EquipManager equipManager = EquipManager.instance;
        equipManager.onUnEquipCallBack += DisableSelectedImage;
    }

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
        equipButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
        equipButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }

    public void Equip()
    {
        bool canEquip = EquipManager.instance.EquipItem(item);
        if (canEquip)
        {
            selectedImageUI.enabled = true;
        }
    }

    public void DisableSelectedImage()
    {
        selectedImageUI.enabled = false;
    }
}
