using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class PickUpNVG : MonoBehaviour {

    private void Update()
    {
        Interactable interact = GetComponent<Interactable>();

        if (interact.interacted)
        {
            EquipNVG();
            interact.interacted = false;
            Destroy(gameObject);
        }
    }

    public void EquipNVG()
    {
        GameObject player = GetPlayer.player;
        player.GetComponentInChildren<NightVision>().usable = true;
    }
}
