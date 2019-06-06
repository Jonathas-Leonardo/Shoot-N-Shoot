using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

	public float current;
	public float step = 1;
	public float realTime;
	public bool isTimer;
	public bool isReset;

	// Use this for initialization
	void Start () {
		current = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(isReset){
			isReset = false;
			ResetTimer();
		}

		if(current < Time.time){
			isTimer=true;
		}
		realTime = Time.time;
	}

	void ResetTimer(){		
		isTimer = false;
		current = Time.time + step;
	}
}