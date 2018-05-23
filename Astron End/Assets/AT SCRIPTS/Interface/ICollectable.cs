using UnityEngine;
public interface ICollectable {
	CollectableItemSpawner Spawner{get;set;}
	ICollectable Spawn(Vector3 postion, CollectableItemSpawner spawner);
	//Waiting for the player script in order to interact with the player param
	void Collect();

}
