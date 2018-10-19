using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOffOn : MonoBehaviour {

	public Collider coll;

	void Start()
	{
		coll = GetComponent<Collider>();
		coll.isTrigger = true;
	}

	// Disables gravity on all rigidbodies entering this collider.
	void OnTriggerEnter(Collider other)
	{
		if (other.attachedRigidbody)
			other.attachedRigidbody.useGravity = true;
	}
}