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
		//AddMove();
		//AddRotation();
		//isSpawn = false;
		gameObject.transform.localScale = Vector3.one * asteroid.size;
		Physics.IgnoreLayerCollision(9,9,false);
	}

	public void AddRotation(){
		rb.AddTorque(Vector3.forward * asteroid.angleSpeed,ForceMode.Impulse);
	}

	public void AddMove(){		
		rb.AddForce(transform.right * asteroid.speed,ForceMode.Impulse);
	}

	public void Spawn(Vector3 vel){
		GameObject asteroid_obj = Instantiate(gameObject,transform.position,transform.rotation);
		//asteroid_obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
		asteroid_obj.name = "AsteroidChild";
		AsteroidBehaviour ast = asteroid_obj.GetComponent<AsteroidBehaviour>();
		//ast.isSpawn = false;
		ast.asteroid.size = (asteroid.size-1);
		ast.asteroid.speed = asteroid.speed+1;
		asteroid_obj.GetComponent<Rigidbody>().AddForce(vel, ForceMode.Impulse);
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag=="Shot" && rb !=null){
			//Debug.Log("force "+ rb.velocity);
			//gameObject.SetActive(false);
			//Destroy(other.gameObject);
			if(asteroid.size>1){
				Spawn(rb.velocity);
				//Spawn();
			}
			Destroy(gameObject);
			
		}
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
}
