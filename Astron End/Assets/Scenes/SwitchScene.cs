﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
	public void NextScene()
	{
		SceneManager.LoadScene("Space Station");
	}
}