using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public enum TYPE { Enemy, Player }

	public int live;
	public int heart;
	public string player_name;
	public int speed;
	public int defense;
	public int power;
	public float handling;
	public int score;
	public TYPE obj_type;

	public Player () {
		live = 1;
		heart = 1;
		player_name = "none";
		speed = 1;
		defense = 1;
		power = 1;
		handling = 1;
		obj_type = 0;
		score = 0;
	}

	public virtual void TakeDamage (int value) {
		Debug.Log ("recebeu dano: " + value);
		heart -= value;
		if (heart < 1) {
			Die ();
		}
	}

	public virtual void Die () {
		Debug.Log (gameObject.name + ": Morrer");
	}

	public virtual void AddScore (int value) {
		Debug.Log ("adicionar ponto: " + value);
		score += value;
	}
}