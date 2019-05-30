using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject canvas;
	public AsteroidBehaviour ast_prefab;
	public GameObject asteroid_grp;
	//public Spawner player_spawner;
	public static SpaceshipBehaviour player_prefab;
	UIBehaviour ui_prefab;

	[SerializeField]
	public static int numberOfAsteroids;
	//public int numberOfAsteroids;

	//GameObject asteroid_prefab;
	void Awake()
	{
		ui_prefab = canvas.GetComponent<UIBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
		if(player_prefab.isDeath){

			ui_prefab.ShowContinueText();
			if(Input.GetKeyDown(KeyCode.Space)){
				player_prefab.Revive();
				ui_prefab.HideContinueText();
			}
		}
	}

	public void getNumberOfAsteroids(){
		//numberOfAsteroids = GetComponentsInChildren<AsteroidBehaviour>().Length;
	}
}
