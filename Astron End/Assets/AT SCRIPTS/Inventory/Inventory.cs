using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More Than one instance of Inventory Found");
            return;
        }

        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 15;

    public List<Item> items = new List<Item>();

    public Vector3 offset;

    public GameObject defaultItem;

    public GameObject defaultModel;

    public bool pickUpIntoHand = false;
    public Toggle toggle;

    private void Start()
    {
        pickUpIntoHand = toggle.isOn;
    }

    public void TogglePickUp()
    {
        pickUpIntoHand = !pickUpIntoHand;
    }

    public bool Add(Item item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Not Enough Room");
            return false;
        }

        items.Add(item);

        if(EquipManager.instance.currentlyEquiped == null && pickUpIntoHand)
        {
            EquipManager.instance.EquipItem(item);
        }

        PopupText.instance.PopUp(1, item, false, null);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }

        return true;
    }

    //Removes it from the inventory without spawning it
    public void RemoveFromInv(Item item)
    {
        EquipManager.instance.UnEquip();
        PopupText.instance.PopUp(-1, item, false, null);

        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    //Removes it from Inv and spawns it
    public void Remove(Item item)
    {
        Vector3 spawnPos = GetPlayer.player.transform.position + GetPlayer.player.transform.forward * 2;
        GameObject obj = Instantiate(defaultItem, spawnPos, GetPlayer.player.transform.rotation);
        obj.GetComponent<ItemPickUp>().item = item;
        obj.GetComponent<ItemPickUp>().item.SetUp(obj.transform);

        RemoveFromInv(item);
    }

    //Spawns the object
    public GameObject SpawnItem(Item item)
    {
        Vector3 spawnPos = GetPlayer.player.transform.position + GetPlayer.player.transform.forward * 2;
        GameObject obj = Instantiate(defaultItem, spawnPos, GetPlayer.player.transform.rotation);
        obj.GetComponent<ItemPickUp>().item = item;
        obj.GetComponent<ItemPickUp>().item.SetUp(obj.transform);

        return obj;
    }
}