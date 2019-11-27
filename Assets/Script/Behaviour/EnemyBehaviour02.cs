using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour02 : Player {

	public int dashSpeed;
	public GameObject gizCheck;
	public bool isMove;
	public bool isAtk;
	Rigidbody rgBody;
	Ray rayLeft;
	Ray rayRight;
	RaycastHit rayhitLeft, rayhitRight;
	public LayerMask layerToCatch;

	GameObject target_obj;

	// Use this for initialization
	void Start () {
		rgBody = GetComponent<Rigidbody> ();
		MoveFordward ();

	}

	// Update is called once per frame
	void Update () {
		rayRight = new Ray (gizCheck.transform.position, -gizCheck.transform.right);
		rayLeft = new Ray (gizCheck.transform.position, gizCheck.transform.right);

		if (!isAtk) {
			CheckRayCast (rayLeft, rayhitLeft);
			CheckRayCast (rayRight, rayhitRight);
		}
	}

	void CheckRayCast (Ray ray, RaycastHit rayhit) {
		if (Physics.Raycast (ray.origin, ray.direction, out rayhit, Mathf.Infinity, layerToCatch)) {
			Debug.DrawRay (ray.origin, ray.direction * rayhit.distance, Color.yellow);
			//Debug.Log ("Did Hit");			
			isAtk = true;
			target_obj = rayhit.transform.gameObject;
			DashAtk ();
		} else {
			Debug.DrawRay (ray.origin, ray.direction * 1000, Color.white);
			//Debug.Log ("Did not Hit");
		}
	}

	void DashAtk () {
		rgBody.velocity = Vector3.zero;
		if (transform.position.x < target_obj.transform.position.x) {
			rgBody.AddForce (transform.right * speed * dashSpeed, ForceMode.Impulse);
		} else {
			rgBody.AddForce (transform.right * -speed * dashSpeed, ForceMode.Impulse);
		}
	}

	void MoveFordward () {
		rgBody.AddForce (transform.up * -speed, ForceMode.Impulse);
	}
}