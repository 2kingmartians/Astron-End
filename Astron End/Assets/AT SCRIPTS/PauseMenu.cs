using UnityEngine;

public class PauseMenu : MonoBehaviour {

    GameObject player;

    public GameObject mainMenu;
    public GameObject gamePlay;
    public GameObject Video;
    public GameObject Audio;

    public GameObject MenuHolder;

    public PlayerSave playerSave;

    bool menusActive = false;
    public bool ableToDisplayMeny = true;

    private void Start()
    {
        DisableAllMenus();
        player = GetPlayer.player;
    }

    public void Update()
    {
        if (ableToDisplayMeny)
        {
            if (Input.GetButtonDown("Cancel") && !menusActive)
            {
                player.GetComponentInChildren<canMouseLook>().enabled = false;
                Time.timeScale = 0.0f;
                toggleCursor.curserEnabled = true;
                MainMenu();
                menusActive = true;
            }
            else if (Input.GetButtonDown("Cancel") && menusActive)
            {
                player.GetComponentInChildren<canMouseLook>().enabled = true;
                Time.timeScale = 1.0f;
                toggleCursor.curserEnabled = false;
                DisableAllMenus();
                menusActive = false;

                /*string[] values = playerSave.valuesNames;

                if(playerSave.theValues.)
                {
                    int i = 0;
                    foreach (string value in values)
                    {
                        if (value == "yRotation")
                        {
                            float rotation = playerSave.theValues[i];
                            GetPlayer.player.transform.localRotation = Quaternion.Euler(0f, rotation, 0f);
                        }
                        if (value == "xRotationCam")
                        {
                            float rotation = playerSave.theValues[i];
                            GetPlayer.player.GetComponentInChildren<Camera>().transform.localRotation = Quaternion.Euler(rotation, 0f, 0f);
                        }

                        i += 1;
                    }
                }

                PlayerSave.control.Save();*/
            }
        }
    }

    public void MainMenu()
    {
        mainMenu.SetActive(true);
        gamePlay.SetActive(false);
        Audio.SetActive(false);
        Video.SetActive(false);
        MenuHolder.SetActive(true);
    }

    public void GamePlayMenu()
    {
        mainMenu.SetActive(false);
        gamePlay.SetActive(true);
        Audio.SetActive(false);
        Video.SetActive(false);
        MenuHolder.SetActive(true);
    }

    public void AudioMenu()
    {
        mainMenu.SetActive(false);
        gamePlay.SetActive(false);
        Audio.SetActive(true);
        Video.SetActive(false);
        MenuHolder.SetActive(true);
    }

    public void VideoMenu()
    {
        mainMenu.SetActive(false);
        gamePlay.SetActive(false);
        Audio.SetActive(false);
        Video.SetActive(true);
        MenuHolder.SetActive(true);
    }

    public void DisableAllMenus()
    {
        MenuHolder.SetActive(false);
    }
}