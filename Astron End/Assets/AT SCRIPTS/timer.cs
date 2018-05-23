using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class timer : MonoBehaviour {

    public TextMeshProUGUI timerText;
    public TimeSpan currentTime;

    GameObject player;

    BoxCollider door;
    SphereCollider mazeBeginning;

    public float timerLength = 5;
    public float seconds;

    bool isInMaze = false;

    public Color Stage1, Stage2, Stage3;
    float stage2Time, stage3Time;

    private void Start()
    {
        seconds = timerLength * 3610;
        stage2Time = seconds / 2;
        stage3Time = seconds / 6;

        door = GetComponentInChildren<BoxCollider>();
        mazeBeginning = GetComponentInChildren<SphereCollider>();
    }

    public void StartTimer()
    {
        isInMaze = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player = other.gameObject;
            
            if (!isInMaze)
            {
                isInMaze = true;
            }
            else if (isInMaze)
            {
                isInMaze = false;
            }
            else
            {
                isInMaze = false;
            }
        }
    }

    private void Update()
    {
        if (isInMaze)
        {
            if (!timerText.gameObject.activeInHierarchy)
            {
                timerText.gameObject.SetActive(true);
            }

            seconds -= Time.deltaTime * 60;

            currentTime = TimeSpan.FromSeconds(seconds);
            string[] tempTime = currentTime.ToString().Split(":"[0]);
            timerText.text = tempTime[0] + ":" + tempTime[1];

            if(seconds > stage2Time)
            {
                timerText.color = Stage1;
            }
            else if (seconds <= stage2Time && seconds > stage3Time)
            {
                timerText.color = Stage2;
            }
            else if (seconds <= stage3Time)
            {
                timerText.color = Stage3;
            }

            if(seconds <= 0)
            {
                player.transform.position = mazeBeginning.transform.position;
                isInMaze = false;
            }

            if (!door.enabled)
            {
                door.enabled = true;
            }

            GetComponent<BoxCollider>().enabled = false;
        }
        else if (!isInMaze)
        {
            if (timerText.gameObject.activeInHierarchy)
            {
                seconds = timerLength * 3610;
                timerText.gameObject.SetActive(false);
            }
            GetComponent<BoxCollider>().enabled = true;
        }
    }
}