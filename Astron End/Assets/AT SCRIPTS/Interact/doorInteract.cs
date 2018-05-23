using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class doorInteract : MonoBehaviour {

    private void Update()
    {
        Interactable interact = GetComponent<Interactable>();

        if (interact.interacted && interact.isInteractable)
        {
            GetComponentInParent<DoorControl>().Interact();
        }
    }
}
