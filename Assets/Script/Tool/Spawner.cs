using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject prefab_obj;
	public GameObject parent_obj;
	private  int NumberOfSpawn;
	private float currentTime;
	public float stepTime;
	public int spawnLimit;
	public enum SPAWNER_TYPE{Single, Plus}
	public SPAWNER_TYPE spawnerType;
	
	private void Start() {
		//NumberOfSpawn=0;

		if(spawnerType == SPAWNER_TYPE.Single){
			Spawn(this.gameObject);
		}
	}

	private void FixedUpdate() {

		if(NumberOfSpawn >= spawnLimit ){
			spawnerType = SPAWNER_TYPE.Single;
		}

		if(spawnerType == SPAWNER_TYPE.Plus){
			if(Time.time>=currentTime){
				Spawn(this.gameObject);
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
		obj.name = obj.name+NumberOfSpawn;
		AddNumberOfSpawn();
	}

	public void Spawn(GameObject parent){
		GameObject obj = Instantiate(prefab_obj, transform.position,transform.rotation);
		obj.name = "Note_"+NumberOfSpawn;
		obj.transform.parent = parent.transform;
		AddNumberOfSpawn();
	}

	public void DoSpawn(){
		NumberOfSpawn=0;
		spawnerType = Spawner.SPAWNER_TYPE.Plus;
	}
}