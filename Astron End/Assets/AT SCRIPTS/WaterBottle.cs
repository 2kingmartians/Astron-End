using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBottle : MonoBehaviour, ICollectable {
	[SerializeField]
	float HPToGiveToPlayer = 20;
	HealthBar playerHealth;
	CollectableItemSpawner _spawner;
	public CollectableItemSpawner Spawner{get{return _spawner;} set{_spawner = value;}}
	public ICollectable Spawn(Vector3 position, CollectableItemSpawner spawner){
		this.Spawner = spawner;
		return Instantiate(this.gameObject,position, Quaternion.identity).GetComponent<ICollectable>();
	}
	public void Collect(){
		playerHealth = playerHealth ?? FindObjectOfType<HealthBar>();
		// Could be great to habe in the health script a method with something like GiveHP
		playerHealth.Currenthp = HPToGiveToPlayer;
		StartCoroutine(Spawner.Counter());
		Destroy(this);
	}
}