using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatcherBehaviour : Player {
	public GameObject target;
	public Spawner spawner;
	public GameObject explosion_pfb;

	// Use this for initialization
	void Start () {
		if (handling == 0) {
			handling = 1;
		}
		handling = Mathf.Clamp (handling, .1f, 10);
	}

	// Update is called once per frame
	void Update () {
		//nothing
	}

	void RotateToTarget (GameObject target, float speed) {
		Vector3 targetPoint = new Vector3 (target.transform.position.x, transform.position.y, target.transform.position.z) - transform.position;
		Quaternion targetRotation = Quaternion.LookRotation (targetPoint, Vector3.up);
		transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime * speed);
	}

	public override void TakeDamage (int value) {
		//base.TakeDamage (value);
		Debug.Log ("teste override " + value);
		heart -= value;
		Die ();
	}

	public override void Die () {
		if (heart < 1) {
			Instantiate (explosion_pfb, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}

	private void OnTriggerEnter (Collider other) {
		if (other.tag == "Shot") {
			Shot shot = other.gameObject.GetComponentInParent<Shot> ();
			if (shot.parentTag == "Player" && shot.colliderTag == "Enemy") {
				TakeDamage (shot.power);
			}
		}
	}

	private void OnTriggerStay (Collider other) {
		if (other.tag == "Player") {
			//target = other.gameObject;
			RotateToTarget (other.gameObject, handling);
			spawner.isStop = false;
		} else {
			spawner.isStop = true;
		}
	}

	private void OnTriggerExit (Collider other) {
		if (other.tag == "Player") {
			target = null;
		}
	}
}