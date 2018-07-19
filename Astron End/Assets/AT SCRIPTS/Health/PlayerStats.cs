using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    #region Singleton
    public static PlayerStats instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    //Character Jump
    public float speed = 6.0f;
    public float sprintSpeed = 8.0f;
    public float jumpSpeed = 8.0f;
    public float jumpGravity = 20.0f;
    public bool isSprinting = false;
}
