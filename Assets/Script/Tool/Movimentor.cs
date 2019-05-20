using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentor : MonoBehaviour {

	public float speed;

	void MoveFordward(float speed){
		transform.position+= Vector3.up * speed;
	}
}
