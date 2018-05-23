using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onOFFlight : MonoBehaviour {

    public float minTime = 0.3f;
    public float maxTime = 1.5f;

	float rNumber;

    private void Awake()
    {
        FindObjectOfType<SOSButton>().lights.Add(gameObject);
    }

    void Update () {
        rNumber += 1 * Time.deltaTime;

        float rStopNo = Random.Range(minTime, maxTime);

        if(rNumber >= rStopNo)
        {
            GetComponent<Light>().intensity = 0.1f;
        }
        if(rNumber >= rStopNo + 0.1f)
        {
            GetComponent<Light>().intensity = 0.5f;
            rNumber = 0;
        }
    }
}
