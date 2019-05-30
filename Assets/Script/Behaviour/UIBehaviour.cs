using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour {

	public Text continueText;

	public void ShowContinueText(){
		continueText.enabled = true;
	}

	public void HideContinueText(){
		continueText.enabled = false;
	}
}
