using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanagement : MonoBehaviour {
    GameObject pausePanel;
    [SerializeField]
    bool paused;
    Camera cam2;
    Camera cam1;
    [SerializeField]
    GameObject mainMenuPanel;
    [SerializeField]
    GameObject SettingsPanel;
    public bool thisIsCurrentCamera =true;
    // Use this for initialization
    void Start() {
        print(Camera.main);
         cam1 = Camera.main;
        print(cam1);
        pausePanel = transform.GetChild(0).gameObject;
        paused = false;
        cam2 = GameObject.Find("Camera2").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() {
        pausePanel.SetActive(paused);
        if (Input.GetKeyDown(KeyCode.Escape)) {
            paused = !paused;
        }
        Time.timeScale = paused == true ? 0 : 1;
        print(Time.timeScale);
    }

    public void Play() {
        paused = false;
    }

    public void StartGame()
    {
        GameObject.Destroy(GameObject.Find("MainMenu"));

    }
    public void Settings()
    {
        SettingsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }
    public void BackToMainMenu()
    {
        mainMenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);


    }
    public void ChangeCamera()
    {
        thisIsCurrentCamera = !thisIsCurrentCamera;
        cam1.enabled = thisIsCurrentCamera;
        cam2.enabled = !thisIsCurrentCamera;
    }

}
