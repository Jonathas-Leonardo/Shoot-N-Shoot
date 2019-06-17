using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceshipUI : MonoBehaviour {

	public Text scoreValueText;
	public Text lifeValueText;

	public void UpdateScoreValueText(int value){
		scoreValueText.text = value.ToString();
	}

	public void UpdateLifeValueText(int value){
		lifeValueText.text = value.ToString();
	}

	public void ShowText(Text text){
		text.enabled = true;
	}

	public void HideText(Text text){
		text.enabled = false;
	}
}