using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

	public Text continueText;
	public Text pauseText;
	public Text gameoverText;

	public void ShowText(Text text){
		text.enabled = true;
	}

	public void HideText(Text text){
		text.enabled = false;
	}
}
