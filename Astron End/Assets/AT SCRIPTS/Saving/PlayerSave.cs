using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System;
using System.IO;

public class PlayerSave : MonoBehaviour {

    GameObject player;
    public GameObject savingText;

    public static PlayerSave control;

    public string[] valuesNames;
    public float[] theValues;

    private void Update()
    {

    }

    private void  Awake()
    {
        control = this;

        //Debug.Log(Application.persistentDataPath);

        player = GetPlayer.player;

        Load();

        savingText.SetActive(false);
    }

    public void Save()
    {
        savingText.SetActive(true);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();

        #region Save

        int length = valuesNames.Length;
        theValues = new float[length];

        int i = 0;
        foreach(string valueName in valuesNames)
        {
            if (valueName == "Health")
            {
                theValues[i] = player.GetComponent<Health>().currentHealth;
            }
            else if (valueName == "xPosition")
            {
                theValues[i] = player.transform.position.x;
            }
            else if (valueName == "yPosition")
            {
                theValues[i] = player.transform.position.y;
            }
            else if (valueName == "zPosition")
            {
                theValues[i] = player.transform.position.z;
            }
            else if(valueName == "yRotation")
            {
                theValues[i] = player.transform.eulerAngles.y;
            }
            else if(valueName == "xRotationCam")
            {
                theValues[i] = player.GetComponentInChildren<Camera>().transform.eulerAngles.x;
            }

            i += 1;
        }

        data.valuesNames = valuesNames;
        data.theValues = theValues;

        #endregion

        bf.Serialize(file, data);
        file.Close();

        savingText.SetActive(false);
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            #region Load

            int i = 0;
            int length = data.theValues.Length - 1;
            foreach(string valueName in data.valuesNames)
            {
                if(valueName == "Health")
                {
                    player.GetComponent<Health>().currentHealth = data.theValues[i];
                }
                else if(valueName == "xPosition")
                {
                    player.transform.position = new Vector3(data.theValues[i], player.transform.position.y, player.transform.position.z);
                }
                else if (valueName == "yPosition")
                {
                    player.transform.position = new Vector3(player.transform.position.x, data.theValues[i], player.transform.position.z);
                }
                else if (valueName == "zPosition")
                {
                    player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, data.theValues[i]);
                }
                else if(valueName == "yRotation")
                {
                    player.transform.localRotation = Quaternion.Euler(player.transform.localRotation.x, data.theValues[i], player.transform.localRotation.z);
                }
                else if(valueName == "xRotationCam")
                {
                    Transform cam = player.GetComponentInChildren<Camera>().transform;
                    cam.localRotation = Quaternion.Euler(data.theValues[i], cam.localRotation.y, cam.localRotation.z);
                }

                i += 1;
            }

            #endregion
        }
        else
        {
            Debug.Log("No Save File");
        }
    }
}

[Serializable]
class PlayerData
{
    public string[] valuesNames;
    public float[] theValues;
}
