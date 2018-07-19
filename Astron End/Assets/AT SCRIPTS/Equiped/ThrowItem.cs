using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowItem : MonoBehaviour {

    public Item itemToThrow;
    public float strength = 500f;
    public float turnSpeed = 800f;

    public void Update()
    {
        if (Input.GetButtonDown("Fire1") && !InventoryUI.instance.inventoryEnabled)
        {
            Throw();
        }
    }

    void Throw()
    {
        GameObject obj = Inventory.instance.SpawnItem(itemToThrow);
        GameObject player = GetPlayer.player.GetComponentInChildren<Camera>().gameObject;

        Inventory.instance.RemoveFromInv(itemToThrow);

        obj.transform.localRotation = Quaternion.Euler(Vector3.zero);

        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.AddForce(player.GetComponentInChildren<Camera>().transform.forward * strength);
        rb.AddTorque(player.transform.right * turnSpeed);
    }
}