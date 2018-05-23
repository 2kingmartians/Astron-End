using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInteraction : MonoBehaviour {

    public float distance = 5f;
    public GameObject cam;

    private void Start()
    {
        cam = GetPlayer.player.GetComponentInChildren<Camera>().gameObject;
    }

    public void Update()
    {
        RaycastHit hit;
        if (cam.gameObject.activeInHierarchy)
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distance))
            {
                if (hit.collider.GetComponent<Interactable>() != null)
                {
                    Interactable interact = hit.collider.GetComponent<Interactable>();
                    if (interact.isInteractable == true)
                    {
                        ChangeColor(Color.green);
                        if (Input.GetButtonDown("Interact"))
                        {
                            interact.interacted = true;
                        }
                    }
                    else
                    {
                        ChangeColor(Color.white);
                    }
                }
                else
                {
                    ChangeColor(Color.white);
                }
            }
            else
            {
                ChangeColor(Color.white);
            }
        }
    }

    void ChangeColor(Color color)
    {
        GetComponent<RawImage>().color = color;
    }
}
