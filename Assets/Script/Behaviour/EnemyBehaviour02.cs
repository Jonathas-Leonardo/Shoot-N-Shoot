using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour02 : MonoBehaviour {

public EnemyBase enemy;
public int dashSpeed;
public GameObject gizCheck;
public bool isMove;
public bool isAtk;
Rigidbody rgBody;

public GameObject target_obj;

	// Use this for initialization
	void Start () {
		rgBody = GetComponent<Rigidbody>();
		MoveFordward();
	}
	
	// Update is called once per frame
	void Update () {

		if(target_obj.transform.position.y>gizCheck.transform.position.y && !isAtk){
			isAtk = true;
			DashAtk();
		}
	}

	void DashAtk(){
		rgBody.velocity = Vector3.zero;
		if(transform.position.x < target_obj.transform.position.x){			
				rgBody.AddForce(transform.right * enemy.speed * dashSpeed, ForceMode.Impulse);
			}else{
				rgBody.AddForce(transform.right * -enemy.speed * dashSpeed, ForceMode.Impulse);
			}
	}

	void MoveFordward(){
		rgBody.AddForce(transform.up * -enemy.speed, ForceMode.Impulse);
	}
}
