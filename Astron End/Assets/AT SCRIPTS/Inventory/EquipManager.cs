using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour {

    #region Singleton
    public static EquipManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("There is more than 1 equipmentManager in the scene");
            return;
        }

        instance = this;
    }
    #endregion

    public delegate void OnUnEquip();
    public OnUnEquip onUnEquipCallBack;

    public GameObject currentlyEquiped;
    public Transform equiedItemHolder;

    public Item item;

    public bool EquipItem(Item _item)
    {
        item = _item;

        if(item.equipedModel == null)
        {
            Debug.LogWarning("There is no equip model for: " + item.name);
            return false;
        }

        if(currentlyEquiped == null)
        {
            currentlyEquiped = Instantiate(item.equipedModel, equiedItemHolder.position, item.equipedModel.transform.rotation);
            currentlyEquiped.transform.SetParent(equiedItemHolder);
        }
        else if(currentlyEquiped != null)
        {
            UnEquip();
            item = _item;
            currentlyEquiped = Instantiate(item.equipedModel, equiedItemHolder.position, item.equipedModel.transform.rotation);
            currentlyEquiped.transform.SetParent(equiedItemHolder);
        }



        Debug.Log("Equip: " + item.name);
        return true;
    }

    public void UnEquip()
    {
        if(currentlyEquiped != null)
        {
            Destroy(currentlyEquiped);
            item = null;
            currentlyEquiped = null;
            if(onUnEquipCallBack != null)
            {
                onUnEquipCallBack.Invoke();
            }
        }
        else
        {
            Debug.Log("Nothing To Unequip");
        }
    }
}
