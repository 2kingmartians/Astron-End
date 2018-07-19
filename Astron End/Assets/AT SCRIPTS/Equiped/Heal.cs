using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour {

    public float increaseBy = 10f;

    public void Update()
    {
        if (Input.GetButtonDown("Fire1") && !InventoryUI.instance.inventoryEnabled)
        {
            GetPlayer.player.GetComponent<Health>().currentHealth += increaseBy;
            Inventory.instance.RemoveFromInv(EquipManager.instance.item);
            EquipManager.instance.UnEquip();
        }
    }
}
