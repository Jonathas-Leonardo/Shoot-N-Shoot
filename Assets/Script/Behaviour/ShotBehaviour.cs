using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehaviour : MonoBehaviour {

	public Shot shot;

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		MoveFordward();		
	}

	public void MoveFordward(){
		rb.AddForce(transform.up * shot.speed,ForceMode.Impulse);
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag=="Wall"){
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag=="Asteroid"){
			Destroy(gameObject);
		}
	}
}
