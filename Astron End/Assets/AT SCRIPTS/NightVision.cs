using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NightVision : MonoBehaviour {

    public float timeRemainingToStart = 2f;
    public float seconds;

    public bool NightVisionEnabled;
    public bool usable = true;

    public Light CameraLight;
    public GameObject OverLay;
    public Slider percentLeft;
    public TextMeshProUGUI text;

    private void Start()
    {
        seconds = timeRemainingToStart * 60;
        ToggleNightVision();
    }

    private void Update()
    {
        if(seconds <= 0)
        {
            usable = false;
            NightVisionEnabled = false;
            ToggleNightVision();
        }

        if (Input.GetButtonDown("NightVision") && usable)
        {
            NightVisionEnabled = !NightVisionEnabled;
            ToggleNightVision();
        }

        if (NightVisionEnabled)
        {
            seconds -= Time.deltaTime;
            float percent = (seconds * 100) / (timeRemainingToStart * 60);
            text.text = percent.ToString("0") + "%";
            percentLeft.value = percent;
        }
    }

    public void ToggleNightVision()
    {
        if (NightVisionEnabled)
        {
            text.gameObject.SetActive(true);
            percentLeft.gameObject.SetActive(true);
            CameraLight.gameObject.SetActive(true);
            OverLay.SetActive(true);
        }
        else if (!NightVisionEnabled)
        {
            text.gameObject.SetActive(false);
            percentLeft.gameObject.SetActive(false);
            CameraLight.gameObject.SetActive(false);
            OverLay.SetActive(false);
        }
        else
        {
            NightVisionEnabled = false;
        }
    }
}
