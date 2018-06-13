using UnityEngine;

public class InventoryUI : MonoBehaviour {

    #region Singleton
    public static InventoryUI instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public Transform itemsParent;
    public GameObject inventoryUI;
    public GameObject craftingUI;
    [HideInInspector]
    public bool inventoryEnabled = false;

    Inventory inventory;

    InventorySlot[] slots;

	// Use this for initialization
	void Start () {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = GetComponentsInChildren<InventorySlot>();

        inventoryUI.SetActive(false);
        craftingUI.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Inventory"))
        {
            if (!inventoryUI.activeInHierarchy)
            {
                inventoryUI.SetActive(true);
                craftingUI.SetActive(true);

                toggleCursor.curserEnabled = true;

                GetPlayer.player.GetComponentInChildren<canMouseLook>().enabled = false;
                GetPlayer.player.GetComponent<characterJump>().enabled = false;

                inventoryEnabled = true;

                Crafting.instance.UpdateCrafting();
            }
            else
            {
                inventoryUI.SetActive(false);
                craftingUI.SetActive(false);

                toggleCursor.curserEnabled = false;

                GetPlayer.player.GetComponentInChildren<canMouseLook>().enabled = true;
                GetPlayer.player.GetComponent<characterJump>().enabled = true;

                inventoryEnabled = false;
            }
        }
	}

    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
