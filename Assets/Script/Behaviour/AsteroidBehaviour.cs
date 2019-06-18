using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour {

	public Asteroid asteroid;
	Rigidbody rb;

	void Awake() {
		rb = GetComponent<Rigidbody>();
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		SetScale(asteroid.size);
		AddRotation(asteroid.angleSpeed);
		AddMove(asteroid.speed);
		Physics.IgnoreLayerCollision(9,9,true);
	}

	public void SetScale(float size){
		gameObject.transform.localScale = Vector3.one * size;
	}

	public void AddRotation(float angleSpeed){
		rb.AddTorque(Vector3.forward * angleSpeed,ForceMode.Impulse);
	}

	public void AddMove(Vector3 speed){		
		rb.AddForce(speed,ForceMode.Impulse);
	}

	public void Slice(Vector3 vel){
		AsteroidBehaviour ast = Instantiate(this,transform.position,transform.rotation);
		ast.asteroid.size = (asteroid.size-1);
		ast.asteroid.speed = vel;
		ast.asteroid.scoreValue = (int)(asteroid.scoreValue/2);
		ast.gameObject.name = "AsteroidChildren";
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Enemy"){
			if(asteroid.size>1){
				Slice(rb.velocity);
				Vector3 rand_velocity = new Vector3(rb.velocity.x+Random.Range(-1,1),rb.velocity.y+Random.Range(-1,1),0);
				Slice(rand_velocity);
			}
			Destroy(gameObject);
		}

		if(other.gameObject.tag=="Player"){
			other.gameObject.GetComponentInParent<SpaceshipBehaviour>().AddScore(asteroid.scoreValue);
			if(asteroid.size>1){
				Slice(rb.velocity);
				Vector3 rand_velocity = new Vector3(rb.velocity.x+Random.Range(-1,1),rb.velocity.y+Random.Range(-1,1),0);
				Slice(rand_velocity);
			}
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag=="Shot"){
			if(asteroid.size>1){
				Slice(rb.velocity);
				Vector3 rand_velocity = new Vector3(rb.velocity.x+Random.Range(-1,1),rb.velocity.y+Random.Range(-1,1),0);
				Slice(rand_velocity);
			}
			Debug.Log("asteroid - tiro ");
			Destroy(gameObject);
			SpaceshipBehaviour spaceship_bhvr = other.gameObject.GetComponent<ShotBehaviour>().spaceship_bhvr;
			if(spaceship_bhvr !=null){
				
				spaceship_bhvr.AddScore(asteroid.scoreValue);
			}
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
