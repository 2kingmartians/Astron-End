using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class SOSButton : MonoBehaviour {

    public timer Alarm;
    AudioSource alarmAudio;

    public AudioClip[] audioToPlay;
    Animation anim;

    public List<GameObject> lights;

    private void Awake()
    {
        alarmAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        Interactable interact = GetComponent<Interactable>();

        if(interact.interacted && interact.isInteractable)
        {
            StartCoroutine(ActivateAlarm());
            interact.isInteractable = false;
        }
    }

    IEnumerator ActivateAlarm()
    {
        anim.Play();
        alarmAudio.clip = audioToPlay[0];
        alarmAudio.loop = false;
        alarmAudio.Play();
        yield return new WaitForSeconds(alarmAudio.clip.length);
        alarmAudio.volume = 0.15f;
        alarmAudio.loop = true;
        alarmAudio.clip = audioToPlay[1];
        alarmAudio.Play();
        Alarm.StartTimer();
    }
}
