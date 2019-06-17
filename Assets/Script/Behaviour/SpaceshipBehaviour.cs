using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipBehaviour : MonoBehaviour {

	public Spaceship spaceship;
	public GameObject shoot_prefab;
	public Transform spawnerShoot;
	public GameObject explosion_prefab;
	public GameObject renders;

	//actions
	public bool isRotateLeft;
	public bool isRotateRight;
	public bool isMoveFordward;
	public bool isShot;
	public bool isTeleport;

	public bool isOver;
	public bool isDeath;
	public bool isRebirth;

	public int score;

	Rigidbody rb;
	SpaceshipUI ui;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		ui = GetComponent<SpaceshipUI>();
		ui.UpdateLifeValueText(spaceship.live);
		ui.UpdateScoreValueText(score);
	}
	
	// Update is called once per frame
	void Update () {
		if(!isDeath){
			if(isRotateLeft){
				RotateLeft();
			}
			if(isRotateRight){
				RotateRight();
			}
			if(isMoveFordward){
				MoveFordward();
			}
			if(isShot){
				isShot = false;
				SpawnShoot();
			}
			if(isTeleport){
				isTeleport = false;
				TeleportRandomMove();
			}
		}
		if(isRebirth){
			isRebirth = false;
			if(isDeath){
				Revive();
				isDeath = false;
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

	private void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Asteroid" || other.gameObject.tag == "Enemy"){
			//DestroyShip();
			//Destroy(gameObject);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		// Debug.Log(other.gameObject.name);
		if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Shot"){
			DestroyShip();
		}
	}

	//Todo

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

    private void SpawnShoot(){
		GameObject obj = Instantiate(shoot_prefab,spawnerShoot.transform.position,spawnerShoot.transform.rotation);
		obj.GetComponent<ShotBehaviour>().master_obj = gameObject;
		obj.GetComponent<ShotBehaviour>().spaceship_bhvr = this;
		obj.name = transform.name+" - tiro";
	}

	private void TeleportRandomMove(){
		Vanish();
		Invoke("ShowShip",1);
	}

	private void ShowShip(){
		rb.isKinematic = false;
		renders.SetActive(true);
		transform.position = new Vector3(transform.position.x,transform.position.y,0);
	}

	private void Vanish(){
		rb.isKinematic = true;
		renders.SetActive(false);
		transform.position = new Vector3(Random.Range(-8,8),Random.Range(-5,5),-10);
	}

	private void Revive(){
		transform.position = Vector3.zero;
		rb.velocity = Vector3.zero;
		rb.detectCollisions = true;
		rb.isKinematic = false;
		renders.SetActive(true);
	}

	public void AddScore(int value){
		score += value;	
		ui.UpdateScoreValueText(score);
	}

	private void AddLive(int value){
		spaceship.live += value;
	}

	private void LiveCheck(){	
		if(spaceship.live==0){
			isOver =true;
		}
	}

	private void DestroyShip(){
		Instantiate(explosion_prefab,transform.position,Quaternion.identity);
		AddLive(-1);
		LiveCheck();
		ui.UpdateLifeValueText(spaceship.live);
		isDeath = true;
		rb.isKinematic = true;
		rb.detectCollisions = false;
		renders.SetActive(false);
	}
}
