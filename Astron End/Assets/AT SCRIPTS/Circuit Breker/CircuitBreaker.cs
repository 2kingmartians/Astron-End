using UnityEngine;


[RequireComponent(typeof(Interactable))]
public class CircuitBreaker : MonoBehaviour {

    public static int breakersCompleted = 0;
    public static GameObject mainDoor;
    public static int totalBreakers = 0;

    public int temp;

    public bool activatedBreaker = false;
    public GameObject doorToOpen;

    Animation anim;
    AudioSource switchSound;

    Interactable interact;

    private void Awake()
    {
        interact = GetComponent<Interactable>();

        anim = GetComponentInChildren<Animation>();

        foreach(Transform temp in doorToOpen.transform.parent)
        {
            if(temp.name == "Main Door")
            {
                mainDoor = temp.gameObject;
            }
        }
        totalBreakers += 1;

        switchSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (interact.interacted && interact.isInteractable && !activatedBreaker)
        {
            switchSound.Play();
            anim.Play("CB_On");
            OpenDoor();
            breakersCompleted += 1;
            activatedBreaker = true;
            interact.interacted = false;
        }
        else if (interact.interacted && interact.isInteractable && activatedBreaker)
        {
            switchSound.Play();
            anim.Play("CB_Off");
            CloseDoor();
            breakersCompleted -= 1;
            activatedBreaker = false;
            interact.interacted = false;
        }

        if (breakersCompleted >= totalBreakers)
        {
            mainDoor.GetComponent<DoorControl>().ableToOpen = true;
        }
        else
        {
            mainDoor.GetComponent<DoorControl>().ableToOpen = false;
        }
    }

    void OpenDoor()
    {
        if(doorToOpen != null)
        {
            doorToOpen.GetComponent<DoorControl>().ableToOpen = true;
        }
    }

    void CloseDoor()
    {
        doorToOpen.GetComponent<DoorControl>().ableToOpen = false;
    }
}
