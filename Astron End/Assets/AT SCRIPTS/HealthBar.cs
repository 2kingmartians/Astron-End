using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    public float Totalhp;

    public float Currenthp;

    // Use this for initialization
    void Start()
    {
        Currenthp = Totalhp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TakeDamage();
        }

    }
    void TakeDamage()
    {
        Currenthp -= 5;

        transform.localScale = new Vector3((Currenthp / Totalhp), 1, 1);
    }
}
