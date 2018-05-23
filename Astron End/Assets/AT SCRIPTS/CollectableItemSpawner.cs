using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class CollectableItemSpawner : MonoBehaviour
{
    [SerializeField]
    List<ItemToSpawn> spawnList = new List<ItemToSpawn>();
    private ICollectable _spawnItem;
    public ICollectable spawnedItem;

    public float RemainingTime = 60f;

    void Start()
    {
        SortItems();
        // First spawn
        SelectAndSpawn();
    }
    public void CollectItem()
    {
        if (spawnedItem == null)
            return;

        spawnedItem.Collect();
        spawnedItem = null;
        StartCoroutine("Counter");
    }
    void SortItems()
    {
        spawnList.OrderBy(x => x.pourcentage);
    }
    void SelectAndSpawn()
    {
        float rdm = Random.Range(0, 100);
        spawnedItem = spawnList.Where(x => x.pourcentage <= rdm)
        .Select(x => x.Item)
        .FirstOrDefault().Spawn(this.transform.position, this);
    }

    public IEnumerator Counter()
    {
        yield return new WaitForSecondsRealtime(RemainingTime);
        SelectAndSpawn();

    }

}

[System.Serializable]
public class ItemToSpawn
{
    public ICollectable Item
    {
        get
        {
            if(items.Count == 1 && items[0].GetComponent<ICollectable>() != null)
                return items[0].GetComponent<ICollectable>();

            return items[Random.Range(0, items.Count)].GetComponent<ICollectable>() ?? null;
        }
    }
    [SerializeField]
    List<GameObject> items = new List<GameObject>();
    [Range(0, 100)]
    public int pourcentage;
}

