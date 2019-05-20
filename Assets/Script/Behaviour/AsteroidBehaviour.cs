using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour {

	public Asteroid asteroid;
	public bool isSpawn;

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		AddMove();
		AddRotation();
		//isSpawn = false;
		gameObject.transform.localScale = Vector3.one * asteroid.size;
	}
	
	// Update is called once per frame
	void Update () {
		if(isSpawn){
			//Spawn();
			isSpawn=false;
		}
	}

	public void AddRotation(){
		rb.AddTorque(Vector3.forward * asteroid.angleSpeed,ForceMode.Impulse);
	}

	public void AddMove(){		
		rb.AddForce(transform.right * asteroid.speed,ForceMode.Impulse);
	}

	public void Spawn(Vector3 vel){
		GameObject asteroid_obj = Instantiate(gameObject,transform.position,Quaternion.identity);
		asteroid_obj.name = "AsteroidChild";
		AsteroidBehaviour ast = asteroid_obj.GetComponent<AsteroidBehaviour>();
		ast.isSpawn = false;
		ast.asteroid.size = (asteroid.size-1);
		ast.asteroid.speed = asteroid.speed+1;
		asteroid_obj.GetComponent<Rigidbody>().AddForce(vel, ForceMode.Impulse);
		//ast.GetComponent<Collider>().isTrigger=true;
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag=="Shot"){
			Debug.Log("force "+ rb.velocity);
			if(asteroid.size>1){
				Spawn(rb.velocity);
				//Spawn();
			}
			Destroy(gameObject);
			Destroy(other.gameObject);
		}
	}

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag=="Wall"){

		}
	}
}
