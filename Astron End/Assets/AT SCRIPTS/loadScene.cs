using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour {

    public static void LoadScene(string sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        Debug.Log("Load Scene: " + sceneIndex);
    }
}
