using System.Collections;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Interactable))]
public class DoorControl : MonoBehaviour
{
    GameObject text; //The floating text by the door

    Animation anim;

    public bool ableToOpen = false;
    public bool opening = false;

    private void Start()
    {
        anim = GetComponentInChildren<Animation>();
        foreach(Transform trans in transform)
        {
            if(trans.name == "Text Display")
            {
                text = trans.gameObject;
            }
        }

        text.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<Interactable>().interacted = false;
        }
    }

    //If the player enters the collision area, make the text visible
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            text.SetActive(false);
            //GetComponent<Interactable>().interacted = false;
        }
    }

    //If the player presses "F" in the collision area, check the doorstate, wait for current animation to end and then open/close the door.
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            text.SetActive(true);
            Interact();
        }
    }

    public void Interact()
    {
        Interactable interact = GetComponent<Interactable>();

        if(ableToOpen && !opening)
        {
            EditText(Color.white, "Press F to Open");
            if(interact.interacted && interact.isInteractable)
            {
                StartCoroutine(DoorAnim());
                interact.interacted = false;
            }
        }
        else if(!ableToOpen && !opening)
        {
            EditText(Color.red, "Open the Breakers");
        }
    }

    IEnumerator DoorAnim()
    {
        opening = true;

        anim.Play("DoorOpen");

        EditText(new Color(Color.red.r, Color.red.g, Color.red.b, 0f), "");

        yield return new WaitForSeconds(2f);

        anim.Play("DoorClose");

        yield return new WaitForSeconds(anim.GetClip("DoorClose").length);

        EditText(new Color(Color.white.r, Color.white.g, Color.white.b, 255f), "");

        opening = false;
    }

    void EditText(Color color, string textToSay)
    {
        foreach (Transform textComp in text.transform)
        {
            textComp.GetComponent<TextMeshPro>().color = color;
            textComp.GetComponent<TextMeshPro>().text = textToSay;
        }
    }
}
