using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTimer : MonoBehaviour
{

private Rigidbody rigid;
[SerializeField]
private Light lightSource;

private float timer = 20f;

void Start () {
	rigid = GetComponent<Rigidbody>();
}

// Update is called once per frame
void Update () {
	timer -= Time.deltaTime;
	if (timer < 0) {
		rigid.useGravity = !rigid.useGravity;
		if (rigid.useGravity)
		{
			lightSource.color = Color.green;
		}
		else {
			lightSource.color = Color.red;
		}

		timer = 15f;
	}
}
}