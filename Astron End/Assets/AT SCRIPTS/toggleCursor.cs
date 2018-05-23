using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleCursor : MonoBehaviour {

    public static bool curserEnabled = false;

    public void Update()
    {
        if (curserEnabled)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (!curserEnabled)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
