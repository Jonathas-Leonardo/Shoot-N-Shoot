using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkHoleBehaviour : MonoBehaviour {

	public DarkHole darkhole;
	// Use this for initialization
	void Start () {
		SetSize (darkhole.size);
	}

	// Update is called once per frame
	void Update () {

	}

	private void OnTriggerStay (Collider other) {
		Debug.Log ("DarkHole to " + other.gameObject.name);
		//		Rigidbody rb = other.gameObject.transform.parent.parent.GetComponent<Rigidbody> ();
		//		Vector3 pos1 = other.gameObject.transform.parent.parent.transform.position;
		//		Vector3 pos2 = transform.position;
		//pos1.z = 0;
		//pos2.z = 0;
		//float angle = Vector3.Angle (pos2, pos1);
		//transform.LookAt();
		//		Vector3 targetDir = pos1 - pos2;
		//		float angle = Vector3.Angle (targetDir, transform.up);
		//float angle2 = transform.LookAt ();
		//		Debug.Log ("angulo " + angle);
		//Debug.Log ("angulo cos: " + Mathf.Cos (angle) + "sen:" + Mathf.Sin (angle));

		//rb.AddForce (new Vector3 (Mathf.Cos (angle) * 5, Mathf.Sin (angle) * 5, 0), ForceMode.Force);
		//other.gameObject.transform.position = Vector3.MoveTowards (other.gameObject.transform.position, gameObject.transform.position, .01f * Time.deltaTime);
		//Vector3.Lerp ();
		//other.gameObject.transform.position += new Vector3 (1, 1, 0) * darkhole.gravity;
	}

	private void OnCollisionEnter (Collision other) {
		Debug.Log ("DarkHole to " + other.gameObject.name);
	}

	public void SetSize (float size) {
		transform.localScale = new Vector3 (1, 1, 1) * size;
	}

	public float Attract () {
		return 0;
	}
}