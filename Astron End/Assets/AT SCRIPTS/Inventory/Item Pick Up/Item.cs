using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    new public string name = "New Item";
    /*[TextArea(2, 5)]
    public string itemDescription = "Item Description";*/
    public Sprite icon = null;

    public GameObject itemModel;
    public Vector3 orientation;

    public GameObject equipedModel;

    public void SetUp(Transform position)
    {
        GameObject obj = Instantiate(itemModel, position.position, Quaternion.Euler(orientation));
        obj.transform.SetParent(position);
        obj.transform.localPosition = Vector3.zero;
    }
}
