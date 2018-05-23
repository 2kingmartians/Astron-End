using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmCollisionControl : MonoBehaviour
{
    public AudioClip audio; //The audiofile
    public AudioSource audioSource; //The physical audiosource in the scene

    //If the player enters the audiofile will be played if the audiosource doesn't play anything at the moment
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if(!audioSource.isPlaying)
            {
                audioSource.spatialBlend = 1f;
                audioSource.PlayOneShot(audio, 0.3f);
            }
        }
    }
}
