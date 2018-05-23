using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateText : MonoBehaviour {

    public void Updatetext()
    {
        FindObjectOfType<ObjectiveManager>().UpdateText();
    }
}
