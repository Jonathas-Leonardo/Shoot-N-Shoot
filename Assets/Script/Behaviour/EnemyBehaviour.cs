using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	public Spaceship spaceship;
	public GameObject shoot_prefab;

	// Use this for initialization
	void Start () {
		//spaceship = new Spaceship();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnShoot(){
		GameObject obj = Instantiate(shoot_prefab,transform.position,Quaternion.identity);
		obj.name = transform.name+" - tiro";
		//obj.GetComponent<Shoot>().power = spaceship.power;
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Enemy"){
			
		}
	}
}
