using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehaviour : Shot {

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		MoveFordward ();
	}

	public void MoveFordward () {
		rb.AddForce (transform.forward * speed, ForceMode.Impulse);
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Wall") {
			Destroy (gameObject);
		}

		if (other.gameObject.tag == "Enemy") {
			colliderTag = "" + other.gameObject.tag;
			if (parentTag == "Player") {
				Player enemy_attr = other.gameObject.GetComponentInParent<Player> ();
				playerObj.GetComponent<Player> ().AddScore (enemy_attr.score);
				Destroy (gameObject);
			}
		}

		if (other.gameObject.tag == "Player") {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag == "Asteroid") {
			Destroy (gameObject);
		}
		if (other.gameObject.tag == "Shot") {
			Destroy (gameObject);
		}
	}
}