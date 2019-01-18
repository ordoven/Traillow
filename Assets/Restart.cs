using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour {

	public GameObject aud;
	public AudioClip sound;

	void OnMouseDown () {
		if (!FindObjectOfType<GameBoardCreator> ().GameOver) {
			FindObjectOfType<score> ().RestartScore ();
			FindObjectOfType<GameBoardCreator> ().Nulinimas ();
			if (Input.GetMouseButtonDown (0)) {
				GetComponent<Animator> ().Play ("Spinner");
				var obj = Instantiate (aud);
				obj.GetComponent<audioPlayer> ().PlaySound (sound, 2);
			}
		}			
	}

	void OnMouseOver() {
		if (!FindObjectOfType<GameBoardCreator> ().GameOver)
			GetComponent<Animator> ().SetBool ("Hover", true);
	}

	void OnMouseExit() {
		GetComponent<Animator> ().SetBool ("Hover", false);
	}
}
