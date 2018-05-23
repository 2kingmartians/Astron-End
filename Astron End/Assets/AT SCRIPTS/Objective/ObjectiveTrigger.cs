using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTrigger : MonoBehaviour {

    public Objective objective;

    private void OnTriggerEnter(Collider other)
    {
        TriggerObjective();
    }

    public void TriggerObjective()
    {
        FindObjectOfType<ObjectiveManager>().Objective(objective);
    }
}
