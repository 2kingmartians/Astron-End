using UnityEngine;

[System.Serializable]
public class Objective {

    public int priority;
    [HideInInspector]
    public bool ObjDone;
    public string objective;
}
