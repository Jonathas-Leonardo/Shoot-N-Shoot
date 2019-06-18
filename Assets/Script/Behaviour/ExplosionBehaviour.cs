using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour {

	float lifeTime;
	ParticleSystem ps;
	// Use this for initialization
	void Start () {
		ps = GetComponent<ParticleSystem>();
		lifeTime =  ps.main.duration;
		Destroy(gameObject, lifeTime);
	}
}
