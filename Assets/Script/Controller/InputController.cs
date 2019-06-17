using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

	public SpaceshipBehaviour player;
	
	// Update is called once per frame
	void Update () {
		player.isRotateLeft = Input.GetKey(KeyCode.J);
		player.isRotateRight = Input.GetKey(KeyCode.L);
		player.isMoveFordward = Input.GetKey(KeyCode.I);
		player.isShot = Input.GetKeyDown(KeyCode.K);
		player.isTeleport = Input.GetKeyDown(KeyCode.Space);
		player.isRebirth = Input.GetKeyDown(KeyCode.R);
	}
}
