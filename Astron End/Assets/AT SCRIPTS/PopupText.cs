using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupText : MonoBehaviour {

    #region Singleton
    public static PopupText instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject popupTextPrefab;

    Transform canvas;

    public float timeDelay = 1.0f;

    public bool popUpStart = false;
    bool canPopUp = false;

    float timer = 0.0f;

    Queue<int> amounts;
    Queue<Item> items;
    Queue<bool> blueprints;
    Queue<Blueprint> recipies;

    private void Start()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        amounts = new Queue<int>();
        items = new Queue<Item>();
        blueprints = new Queue<bool>();
        recipies = new Queue<Blueprint>();
    }

    public void PopUp(int amount, Item item, bool blueprint, Blueprint recipie)
    {
        amounts.Enqueue(amount);
        items.Enqueue(item);
        blueprints.Enqueue(blueprint);
        recipies.Enqueue(recipie);
    }

    void PopUpInternat(int amount, Item item, bool blueprint, Blueprint recipie)
    {
        GameObject popUp = Instantiate(popupTextPrefab);
        popUp.transform.SetParent(canvas, false);
        string text = "";
        if (amount > 0)
        {
            text += "+";
        }

        text = text + amount + " " + item.name;

        if (blueprint)
        {
            text += " Blueprint";
        }

        popUp.GetComponent<TextMeshProUGUI>().text = text;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeDelay)
        {
            if(amounts.Count > 0)
            {
                PopUpInternat(amounts.Dequeue(), items.Dequeue(), blueprints.Dequeue(), recipies.Dequeue());
                timer = 0;
            }
        }
    }
}
