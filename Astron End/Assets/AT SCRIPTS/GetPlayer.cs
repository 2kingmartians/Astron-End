using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayer : MonoBehaviour {

    public static GameObject player;
    public bool active = false;

    private void Awake()
    {
        player = gameObject;
    }
    public void Update()
    {
        if (active)
        {
            Debug.Log(transform.rotation.y);
        }
    }
}
