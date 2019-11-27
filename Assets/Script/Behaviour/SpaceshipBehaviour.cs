using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipBehaviour : Player {

	public Shot shoot_prefab;
	public Transform spawnerShoot;
	public GameObject explosion_prefab;
	public GameObject renders;

	public delegate void VoidDelegate ();
	VoidDelegate[] myMultiDelegate;

	//actions
	public bool isRotateLeft;
	public bool isRotateRight;
	public bool isMoveFordward;
	public bool isShot;
	public bool isTeleport;

	public bool isOver;
	public bool isDeath;
	public bool isRebirth;

	Rigidbody rb;
	SpaceshipUI ui;
	InputController input_spaceship;
	GameManager gm;

	// Use this for initialization
	void Start () {
		//myMultiDelegate = new VoidDelegate[]{RotateLeft, RotateRight};
		//var t = myMultiDelegate[0];

		rb = GetComponent<Rigidbody> ();
		gm = FindObjectOfType<GameManager> ();
		ui = FindObjectOfType<SpaceshipUI> ();
		UpdateUI ();
		input_spaceship = GetComponent<InputController> ();
		if (input_spaceship != null) {
			input_spaceship.player = this;
		}
	}

	// Update is called once per frame
	void Update () {
		if (!isDeath) {
			if (isRotateLeft) {
				RotateLeft ();
			}
			if (isRotateRight) {
				RotateRight ();
			}
			if (isMoveFordward) {
				MoveFordward ();
			}
			if (isShot) {
				isShot = false;
				SpawnShoot ();
			}
			if (isTeleport) {
				isTeleport = false;
				TeleportRandomMove ();
			}
		} else {
			gm.RestartGame (isDeath);
		}
		if (isRebirth) {
			isRebirth = false;

			if (isDeath && !isOver) {
				Revive ();
				isDeath = false;
				gm.RestartGame (isDeath);
			}
		}
	}

	private void OnTriggerStay (Collider other) {
		float leftLimit = -9f;
		float rigthLimit = 9f;
		float topLimit = 6;
		float bottomLimit = -6;
		if (other.gameObject.tag == "Wall") {
			Vector3 pos = transform.position;
			if (pos.x < leftLimit) {
				transform.position = new Vector3 (8.5f, pos.y, pos.z);
			} else if (pos.x > rigthLimit) {
				transform.position = new Vector3 (-8.5f, pos.y, pos.z);
			} else if (pos.y > topLimit) {
				transform.position = new Vector3 (pos.x, -5.5f, pos.z);
			} else if (pos.y < bottomLimit) {
				transform.position = new Vector3 (pos.x, 5.5f, pos.z);
			}
		}
	}

	private void OnTriggerEnter (Collider other) {
		//Debug.Log ("Spaceship - " + other.gameObject.name);
		if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Shot") {
			DestroyShip ();
		}

		if (other.gameObject.tag == "Asteroid") {
			DestroyShip ();
		}
	}

	private void UpdateUI () {
		if (ui != null) {
			ui.UpdateScoreValueText (score);
			ui.UpdateLifeValueText (live);
		}
	}

	//Todo

	private void RotateLeft () {
		transform.rotation *= Quaternion.AngleAxis (handling, -Vector3.up);
	}

	private void RotateRight () {
		transform.rotation *= Quaternion.AngleAxis (handling, Vector3.up);
	}

	private void MoveFordward () {
		rb.AddForce (transform.forward * speed * .1f, ForceMode.Impulse);
	}

	private void SpawnShoot () {
		Shot obj = Instantiate (shoot_prefab, spawnerShoot.transform.position, spawnerShoot.transform.rotation);
		obj.GetComponent<Shot> ().parentTag = gameObject.tag;
		obj.GetComponent<Shot> ().playerObj = this;
		obj.name = transform.name + " - tiro";
	}

	private void TeleportRandomMove () {
		Vanish ();
		Invoke ("ShowShip", 1);
	}

	private void ShowShip () {
		rb.isKinematic = false;
		renders.SetActive (true);
		transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
	}

	private void Vanish () {
		rb.isKinematic = true;
		renders.SetActive (false);
		transform.position = new Vector3 (Random.Range (-8, 8), Random.Range (-5, 5), -10);
	}

	private void Revive () {
		transform.position = Vector3.zero;
		rb.velocity = Vector3.zero;
		rb.detectCollisions = true;
		rb.isKinematic = false;
		renders.SetActive (true);
	}

	public override void AddScore (int value) {
		base.AddScore (value);
		UpdateUI ();
	}

	public override void Die () {
		base.Die ();
		Instantiate (explosion_prefab, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}

	private void AddLive (int value) {
		live += value;
		UpdateUI ();
	}

	private void LiveCheck () {
		if (live == 0) {
			isOver = true;
			isDeath = true;
		} else {
			isDeath = true;
		}
	}

	private void DestroyShip () {
		Instantiate (explosion_prefab, transform.position, Quaternion.identity);
		AddLive (-1);
		LiveCheck ();
		rb.isKinematic = true;
		rb.detectCollisions = false;
		renders.SetActive (false);
	}
}