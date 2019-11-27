using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warper : MonoBehaviour {

	public GameObject target;

	private void OnTriggerEnter (Collider other) {
		if (other.gameObject.GetComponent<Warp> () == null) {
			other.gameObject.GetComponentInParent<Rigidbody> ().transform.position = target.transform.position;
			if (target.gameObject.GetComponent<Warper> () != null) {
				other.gameObject.AddComponent<Warp> ().nameCollider = target.name;
			}
		}
	}
}

public class Warp : MonoBehaviour {

	public string nameCollider = "";

	private void OnTriggerExit (Collider other) {
		if (nameCollider == other.gameObject.name) {
			Destroy (this);
		}
	}
}