using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

	Text txt;
	public Color tooMuch;
	public Color tooLess;
	public int total = 0;
	public int scr = 0;
	public string sentence;

	void Start() {
		txt = GetComponent<Text> ();
		txt.text = sentence + "   " + scr.ToString () + "/" + total.ToString ();
	}

	public void UpdateScore(int value) {
		scr += value;
		txt.text = sentence + "   " + scr.ToString () + "/" + total.ToString ();
		if (scr > total) {
			txt.color = tooMuch;
		} else {
			txt.color = tooLess;
		}
	}

	public void RestartScore() {
		scr = 0;
		txt.text = sentence + "   " + scr.ToString () + "/" + total.ToString ();
		if (scr > total) {
			txt.color = tooMuch;
		} else {
			txt.color = tooLess;
		}
	}
}
