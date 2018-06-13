using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour {

    public float increaseBy = 10f;
    public string intState;

    public float lengthOfClip;

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GetPlayer.player.GetComponent<Health>().currentHealth += increaseBy;
            EquipManager.instance.UnEquip();
            Inventory.instance.RemoveFromInv(EquipManager.instance.item);
        }
    }
}
