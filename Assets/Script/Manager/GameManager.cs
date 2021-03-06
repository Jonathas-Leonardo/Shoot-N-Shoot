﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Spawner asteroid_spawner;
	public Spawner enemy_spawner;
	public Spawner player_spawner;
	public SpaceshipBehaviour spaceship_bhv;
	public bool isPause;
	public bool isGameOver;
	public bool isRestartGame;
	GameUI ui;

	//GameObject asteroid_prefab;
	void Awake () {
		//player_spawner.prefab_obj = spaceship_bhv.gameObject;
		//input_ctrl.player = spaceship_bhv;
		//hud.spaceship = spaceship_bhv.spaceship;
		ui = GetComponent<GameUI> ();
	}

	// Update is called once per frame
	void Update () {

		// ui.continueText.enabled = spaceship_bhv.isDeath;
		// ui.gameoverText.enabled = spaceship_bhv.isOver;
		// ui.pauseText.enabled = isPause;

		if (Input.GetKeyDown (KeyCode.P)) {
			PauseGame ();
		}
	}

	public void GameOver (bool value) {
		ui.gameoverText.enabled = value;
	}

	public void RestartGame (bool value) {
		ui.continueText.enabled = value;
	}

	public void PauseGame () {
		isPause = !isPause;
		if (isPause) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}
}