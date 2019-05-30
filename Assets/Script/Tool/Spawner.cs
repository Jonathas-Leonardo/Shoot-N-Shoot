using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject prefab_obj;
	private int NumberOfSpawn;
	private float currentTime;
	public int times = 1;
	public float stepTime = 1;
	public bool isStop;

	private void FixedUpdate() {

		if(NumberOfSpawn >= times ){
			isStop=true;
		}

		if(!isStop){
			if(Time.time >= currentTime){
				Spawn();
				AddCurrentTime();
			}
		}
	}

	public void AddNumberOfSpawn(){
		NumberOfSpawn++;
		GameManager.numberOfAsteroids++;
	}

	public void AddCurrentTime(){
		currentTime = Time.time + stepTime;
	}

	public void Spawn(){
		GameObject obj = Instantiate(prefab_obj, transform.position,transform.rotation);
		obj.name = gameObject.name +"_"+ NumberOfSpawn;
		obj.transform.parent = gameObject.transform;
		AddNumberOfSpawn();
	}
}