using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class ItemPickUp : MonoBehaviour {

    Interactable interact;

    public Item item;

    private void Awake()
    {
        interact = GetComponent<Interactable>();
    }

    private void Update()
    {
        if (interact.interacted)
        {
            PickUp();
            interact.interacted = false;
        }
    }

    void PickUp()
    {
        Debug.Log("Picking Up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);

        if (wasPickedUp)
        {
            gameObject.SetActive(false);
        }
    }
}
