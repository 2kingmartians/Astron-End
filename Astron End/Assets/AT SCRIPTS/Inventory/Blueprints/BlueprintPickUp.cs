using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintPickUp : MonoBehaviour {

    public Blueprint blueprint;

    Interactable interact;

    private void Start()
    {
        interact = GetComponent<Interactable>();
    }

    private void Update()
    {   
        if (interact != null)
        {
            if (interact.interacted)
            {
                PickUp();
                interact.interacted = false;
            }
        }
    }

    void PickUp()
    {
        Debug.Log("Picking up Blueprint: " + blueprint.unlockedRecipe.Result.name);
        BlueprintManager.instance.AddBluePrint(blueprint);
        Destroy(gameObject);
    }
}
