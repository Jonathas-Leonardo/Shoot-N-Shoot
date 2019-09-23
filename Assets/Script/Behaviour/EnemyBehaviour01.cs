using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour01 : MonoBehaviour {

	public EnemyBase enemy;
	public ShotBehaviour shoot_prefab;
	public Transform[] shotSpawner;

	float currentTime = 0;
	public float timeToShoot = 1;

	Rigidbody rgBody;

	// Use this for initialization
	void Start () {
		enemy = new EnemyBase();
		enemy.enemy_name = "godofredo";
		//spaceship = new Spaceship();
		currentTime = Time.time;
		rgBody = GetComponent<Rigidbody>();
		//MoveFordward();
	}
	
	// Update is called once per frame
	void Update () {
		if(enemy.isShot){
			for (int i = 0; i < shotSpawner.Length; i++)
			{
				SpawnShoot(shotSpawner[i]);
			}
			enemy.isShot = false;
		}
		enemy.isShot = VerifyTimeToToShot();
	}

	bool VerifyTimeToToShot(){
		if(currentTime + timeToShoot < Time.time){
			currentTime = Time.time;
			return true;
		}
		return false;
	}

	void MoveFordward(){
		rgBody.AddForce(transform.up * -enemy.speed, ForceMode.Impulse);
	}

	void SpawnShoot(Transform spawner_position){
		ShotBehaviour obj = Instantiate(shoot_prefab,spawner_position.transform.position,spawner_position.transform.rotation);
		obj.name = transform.name+" - tiro";
		obj.master_obj = gameObject;
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Enemy"){
			
		}
	}
}
