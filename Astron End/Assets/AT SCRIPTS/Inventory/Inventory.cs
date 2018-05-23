using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More Than one instance of Inventory Found");
            return;
        }

        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 15;

    public List<Item> items = new List<Item>();

    public Vector3 offset;

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                Debug.Log("Not Enough Room");
                return false;
            }
            items.Add(item);

            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }

        return true;
    }

    public void RemoveFromInv(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public void Remove(Item item)
    {
        if(item.obj == null)
        {
            Debug.LogError("There was no object set for: " + item.name);
            return;
        }

        Vector3 spawnPos = GetPlayer.player.transform.position + GetPlayer.player.transform.forward * 2;

        GameObject obj = Instantiate(item.obj, spawnPos, GetPlayer.player.transform.rotation);

        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
