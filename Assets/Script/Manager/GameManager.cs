using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public AsteroidBehaviour ast_behaviour;
	public GameObject asteroid_grp;

	[SerializeField]
	public static int numberOfAsteroids;
	//public int numberOfAsteroids;

	//GameObject asteroid_prefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P)){
			//ast_behaviour.asteroid = asteroid;
			//ast_behaviour.Spawn(Vector3.zero);
			//getNumberOfAsteroids();
		}
	}

	public void getNumberOfAsteroids(){
		//numberOfAsteroids = GetComponentsInChildren<AsteroidBehaviour>().Length;
	}
}
