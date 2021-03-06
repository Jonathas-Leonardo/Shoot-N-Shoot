﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoBehaviour : Player {

	public GameObject center;
	public GameObject body;
	public GameObject shoot_prefab;
	public GameObject explosion_prefab;
	public Transform spawnerShoot;
	public Transform direction;

	//Actions
	public bool isShoot;
	public bool isChange;
	public bool isRest;

	//AI
	float timeToShoot = 1;
	float timeToWait = 2;
	float timeToChange = 5;

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		ChangeDirection ();
		AddMove ();
	}

	void AddMove () {
		rb.AddForce (direction.right * speed, ForceMode.Impulse);
	}

	void ChangeDirection () {
		direction.rotation = Quaternion.AngleAxis (Random.Range (0, 360), transform.forward);
	}

	void Update () {
		rotateCenter ();
		if (isShoot && isRest) {
			isShoot = false;
			SpawnShoot ();
		}

		if (isChange) {
			isChange = false;
			rb.velocity = Vector3.zero;
			ChangeDirection ();
			AddMove ();
		}
	}

	void FixedUpdate () {
		if (Time.timeSinceLevelLoad % timeToShoot == 0) {
			isShoot = true;
		}

		if (Time.timeSinceLevelLoad % timeToWait == 0) {
			isRest = !isRest;
		}

		if (Time.timeSinceLevelLoad % timeToChange == 0) {
			isChange = true;
		}
	}

	void rotateCenter () {
		center.transform.rotation *= Quaternion.AngleAxis (handling, Vector3.up);
	}

	void SpawnShoot () {
		GameObject obj = Instantiate (shoot_prefab, spawnerShoot.transform.position, spawnerShoot.transform.rotation);
		obj.name = transform.name + " - tiro";
	}

	public override void Die () {
		base.Die ();
		//gameObject.SetActive (false);
		Instantiate (explosion_prefab, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}

	private void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			Player player = other.gameObject.GetComponentInParent<Player> ();
			TakeDamage (1);
			if (heart < 1) {
				player.AddScore (score);
			}
		}

		if (other.gameObject.tag == "Shot") {
			Shot shot = other.gameObject.GetComponentInParent<Shot> ();
			if (shot.parentTag == "Player") {
				TakeDamage (shot.power);
			}
		}

		if (other.gameObject.tag == "Asteroid") {
			TakeDamage (800);
		}
	}

	private void OnTriggerStay (Collider other) {
		float leftLimit = -9f;
		float rigthLimit = 9f;
		float topLimit = 6;
		float bottomLimit = -6;
		if (other.gameObject.tag == "Wall") {
			Vector3 pos = transform.position;
			if (pos.x < leftLimit) {
				transform.position = new Vector3 (8.5f, pos.y, pos.z);
			} else if (pos.x > rigthLimit) {
				transform.position = new Vector3 (-8.5f, pos.y, pos.z);
			} else if (pos.y > topLimit) {
				transform.position = new Vector3 (pos.x, -5.5f, pos.z);
			} else if (pos.y < bottomLimit) {
				transform.position = new Vector3 (pos.x, 5.5f, pos.z);
			}
		}
	}
}