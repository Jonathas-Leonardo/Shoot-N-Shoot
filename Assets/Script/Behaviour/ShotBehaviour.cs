using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehaviour : MonoBehaviour {

	public Shot shot;
	public GameObject master_obj;
	Rigidbody rb;
	//public SpaceshipBehaviour spaceship_bhvr;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		MoveFordward();		
	}

	public void MoveFordward(){
		rb.AddForce(transform.forward * shot.speed,ForceMode.Impulse);
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag=="Wall"){
			Destroy(gameObject);
		}

		if(other.gameObject.tag=="Enemy"){
			Destroy(gameObject);
		}

		if(other.gameObject.tag=="Player"){
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag=="Asteroid"){
			//spaceship_bhvr.AddScore(asteroid.scoreValue);
			Destroy(gameObject);
		}
		if(other.gameObject.tag=="Shot"){
			Destroy(gameObject);
		}
	}
}
