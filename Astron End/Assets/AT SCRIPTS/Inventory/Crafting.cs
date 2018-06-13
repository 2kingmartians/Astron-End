using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Crafting : MonoBehaviour {
    #region Singleton
    public static Crafting instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("WARNNG! There is more that 1 crafing script in this scene!");
            return;
        }

        instance = this;
    }
    #endregion

    public Recipie[] recipies;
    public List<Recipie> availableRecipies;

    public Item[] itemsInInvntory;

    public TextMeshProUGUI resultName;
    public Recipie currentRecipie;
    public Image Slot01;
    public Image Slot02;
    public Image Result;
    public Button Next;
    public Button Back;
    public Button CraftIt;

    public int index = 0;

    public int i = 0;
    public int x = 0;

    public void Start()
    {        
        recipies = Resources.LoadAll<Recipie>("Recipies");
    }

    public void UpdateCrafting()
    {
        GetItemsInInventory();
        CheckForRecipies();
        UpdateUI();
    }

    void CheckForRecipies()
    {
        availableRecipies.Clear();

        if(itemsInInvntory.Length == 0)
        {
            Debug.Log("No Items In Inventory");
            return;
        }

        i = 0;
        x = 0;

        foreach(Recipie recipie in recipies)
        {
            List<Item> previousItems = new List<Item>();
            foreach (Item item in itemsInInvntory)
            {
                if(!previousItems.Contains(item)) {
                    if (item == recipie.Input01 || item == recipie.Input02)
                    {
                        x += 1;
                    }
                    previousItems.Add(item);
                }
            }

            if(x >= 2)
            {
                if (!availableRecipies.Contains(recipies[i]))
                {
                    availableRecipies.Add(recipies[i]);
                }
            }
            i += 1;
            x = 0;
        }
    }

    public void UpdateUI()
    {
        if (index == (availableRecipies.Count - 1))
        {
            Next.interactable = false;
        }
        else
        {
            Next.interactable = true;
        }

        if (index == 0)
        {
            Back.interactable = false;
        }
        else
        {
            Back.interactable = true;
        }

        if (availableRecipies.Count == 0)
        {
            Debug.Log("No Recipies");
            currentRecipie = null;
            Slot01.gameObject.SetActive(false);
            Slot02.gameObject.SetActive(false);
            Result.gameObject.SetActive(false);
            resultName.text = "No Recipies Available";

            Next.interactable = false;
            Back.interactable = false;
            CraftIt.interactable = false;

            return;
        }
        else
        {
            Slot01.gameObject.SetActive(true);
            Slot02.gameObject.SetActive(true);
            Result.gameObject.SetActive(true);

            CraftIt.interactable = true;
        }

        currentRecipie = availableRecipies[index];
        Slot01.sprite = currentRecipie.Input01.icon;
        Slot02.sprite = currentRecipie.Input02.icon;
        Result.sprite = currentRecipie.Result.icon;
        resultName.text = currentRecipie.Result.name;
    }

    void GetItemsInInventory()
    {
        itemsInInvntory = Inventory.instance.items.ToArray();
    }

    public void NextRecipie()
    {
        index += 1;
        UpdateUI();
    }

    public void BackRecipie()
    {
        index -= 1;
        UpdateUI();
    }

    public void CraftItem()
    {
        Craft(currentRecipie.Input01, currentRecipie.Input02, currentRecipie.Result);
        UpdateCrafting();
    }

    void Craft(Item input01, Item input02, Item result)
    {
        Inventory inv = Inventory.instance;

        inv.RemoveFromInv(input01);
        inv.RemoveFromInv(input02);
        inv.Add(result);

        index = 0;
        UpdateCrafting();
    }
}