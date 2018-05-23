using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour {

    float timer;
    public float damageAfterSecs;
    public float damage;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            timer += Time.deltaTime;
            if(timer >= damageAfterSecs)
            {
                other.GetComponent<Health>().TakeDamage(damage);

                timer = 0;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            timer = 0;
        }
    }
}
