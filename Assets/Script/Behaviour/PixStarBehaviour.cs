using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixStarBehaviour : MonoBehaviour {

	Renderer rend;
	float currentLerp=0;
	float minCurrentLerp = 0;
	float maxCurrentLerp = 1;
	public float lerpStep = .1f;
	public Color32 cor;
	public Color32 corAlpha;

	// Use this for initialization
	void Start () {
		currentLerp = minCurrentLerp;
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		Shiny();
	}

	void Shiny(){
		currentLerp += lerpStep;
		rend.material.color = Color32.Lerp(cor, corAlpha,Mathf.PingPong(currentLerp,maxCurrentLerp));		
	}
	
}
