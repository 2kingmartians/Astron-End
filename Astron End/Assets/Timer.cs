using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public float AstronTimer = 180; //3 mins in seconds 
    public Text timerText;

    void Start()
    {
        timerText = GameObject.Find("TimerText").GetComponent<Text>();
    }

    void Update()
    {
        AstronTimer -= Time.deltaTime;
        string mins = ((int)AstronTimer / 60).ToString();
        string seconds = (AstronTimer % 60).ToString("f2");
        if (((int)AstronTimer / 60) < 2)
        {
            timerText.color = Color.yellow;
        }
        if (((int)AstronTimer / 60) < 1)
        {
            timerText.color = Color.red;
        }
		if (((int)AstronTimer / 1) < 0) 
		{
			timerText.color = Color.black;

			UnityEngine.SceneManagement.SceneManager.LoadScene(3);
		}

			
        timerText.text = mins + ":" + seconds;
    }
}
