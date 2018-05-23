using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteObjective : MonoBehaviour {

    public string objective;

    public void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<ObjectiveManager>().CompleteObjective(objective);
    }
}
