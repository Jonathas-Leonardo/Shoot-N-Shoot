using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour01 : Player {

	public ShotBehaviour shoot_prefab;
	public Transform[] shotSpawner;
	float currentTime = 0;
	public float timeToShoot = 1;
	Rigidbody rgBody;
	public bool isShot;

	// Use this for initialization
	void Start () {
		player_name = "godofredo";
		currentTime = Time.time;
		rgBody = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		if (isShot) {
			for (int i = 0; i < shotSpawner.Length; i++) {
				SpawnShoot (shotSpawner[i]);
			}
			isShot = false;
		}
		isShot = VerifyTimeToToShot ();
	}

	bool VerifyTimeToToShot () {
		if (currentTime + timeToShoot < Time.time) {
			currentTime = Time.time;
			return true;
		}
		return false;
	}

	void MoveFordward () {
		rgBody.AddForce (transform.up * -speed, ForceMode.Impulse);
	}

	void SpawnShoot (Transform spawner_position) {
		ShotBehaviour obj = Instantiate (shoot_prefab, spawner_position.transform.position, spawner_position.transform.rotation);
		obj.name = transform.name + " - tiro";
		obj.GetComponent<Shot> ().parentTag = gameObject.tag;
		//obj.GetComponent<Shot> ().parentObj = gameObject;
	}
	private void OnTriggerEnter (Collider other) {
		Debug.Log (other.tag);
		if (other.tag == "Shot") {
			Shot shot = other.gameObject.GetComponentInParent<Shot> ();
			//Debug.Log (shot.parentObj);
			if (shot.parentTag == "Player") {
				Destroy (gameObject);
				//	Instantiate (explosion_pfb);
			}
		}
	}
}