using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipBehaviour : MonoBehaviour {

	public Spaceship spaceship;
	public GameObject shoot_prefab;
	public Transform spawnerShoot;
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
}
