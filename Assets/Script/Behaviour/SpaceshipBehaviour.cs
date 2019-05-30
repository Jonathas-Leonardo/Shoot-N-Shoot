using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipBehaviour : MonoBehaviour {

	public Spaceship spaceship;
	public GameObject shoot_prefab;
	public Transform spawnerShoot;
	public GameObject explosion_prefab;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		//spaceship = new Spaceship();
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.J)){
			RotateLeft();
		}
		if(Input.GetKey(KeyCode.L)){
			RotateRight();
		}
		if(Input.GetKey(KeyCode.I)){
			MoveFordward();
		}
		if(Input.GetKeyDown(KeyCode.K)){
			SpawnShoot();
		}
	}

    private void RotateLeft()
    {
        transform.rotation *= Quaternion.AngleAxis(spaceship.handling,Vector3.forward);
    }

    private void RotateRight()
    {
        transform.rotation *= Quaternion.AngleAxis(spaceship.handling,-Vector3.forward);
    }

    private void MoveFordward()
    {
        rb.AddForce(transform.up * spaceship.speed*.1f,ForceMode.Impulse);
    }

    void SpawnShoot(){
		GameObject obj = Instantiate(shoot_prefab,spawnerShoot.transform.position,transform.rotation);
		obj.name = transform.name+" - tiro";
		//obj.GetComponent<Shoot>().power = spaceship.power;
	}

	private void OnTriggerStay(Collider other) {
		float leftLimit = -9f;
		float rigthLimit = 9f;
		float topLimit = 6;
		float bottomLimit = -6;
		if(other.gameObject.tag=="Wall"){
			Vector3 pos = transform.position;
			if(pos.x < leftLimit){
				transform.position = new Vector3(8.5f,pos.y,pos.z);
			}
			else if(pos.x> rigthLimit){
				transform.position = new Vector3(-8.5f,pos.y,pos.z);
			}
			else if(pos.y > topLimit){
				transform.position = new Vector3(pos.x,-5.5f,pos.z);
			}
			else if (pos.y < bottomLimit){
				transform.position = new Vector3(pos.x,5.5f,pos.z);
			}
		}
	}

	private void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Asteroid"){
			gameObject.SetActive(false);
			GameObject obj = Instantiate(explosion_prefab,transform.position,Quaternion.identity) as GameObject;
			//Destroy(gameObject);
		}
	}
}
