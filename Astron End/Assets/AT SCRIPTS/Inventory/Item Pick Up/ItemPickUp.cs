using UnityEngine;

public class ItemPickUp : MonoBehaviour {

    Interactable interact;

    public Item item;

    private void OnEnable()
    {
        if(item != null)
        {
            item.SetUp(transform);
        }

        interact = GetComponentInChildren<Interactable>();

        if (GetComponent<MeshRenderer>() != null)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void Update()
    {
        if (interact == null)
        {
            if(GetComponentInChildren<Interactable>() != null)
            {
                interact = GetComponentInChildren<Interactable>();
            }
            else
            {
                Debug.LogError("There is no Interactable Script on the child of: " + name);
            }
        }

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
            Destroy(gameObject);
        }
    }
}
