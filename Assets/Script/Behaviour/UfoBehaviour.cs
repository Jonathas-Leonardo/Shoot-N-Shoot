using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoBehaviour : MonoBehaviour {

	public Ufo ufo;
	public GameObject center;
	public GameObject body;
	public GameObject shoot_prefab;
	public GameObject explosion_prefab;
	public Transform spawnerShoot;
	public Transform direction;
	public bool isShoot;
	public bool isChange;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		//by force;
		rb = GetComponent<Rigidbody>();
		ChangeDirection();
		addMove();
	}

	void addMove(){		
		rb.AddForce(direction.right*ufo.speed,ForceMode.Impulse);
	}

	void ChangeDirection(){
		direction.rotation = Quaternion.AngleAxis(Random.Range(0,361),Vector3.forward);
	}
	
	// Update is called once per frame
	void Update () {
		center.transform.rotation *= Quaternion.AngleAxis(ufo.angleSpeed,Vector3.up);
		if(isShoot){
			isShoot=false;
			SpawnShoot();
		}

		if(isChange){
			isChange=false;
			rb.velocity = Vector3.zero;
			ChangeDirection();
			addMove();
		}
	}

	void SpawnShoot(){
		GameObject obj = Instantiate(shoot_prefab,spawnerShoot.transform.position,spawnerShoot.transform.rotation);
		obj.name = transform.name+" - tiro";
	}

	private void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Player"){
			gameObject.SetActive(false);
			Instantiate(explosion_prefab,transform.position,Quaternion.identity);
			//Destroy(gameObject);
		}
	}

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player"){
			gameObject.SetActive(false);
			Instantiate(explosion_prefab,transform.position,Quaternion.identity);
			//Destroy(gameObject);
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
