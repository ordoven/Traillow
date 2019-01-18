using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goHome : MonoBehaviour {

	void OnMouseDown () {
		SceneManager.LoadScene ("lvlSelect");
	}

	void OnMouseOver() {
		GetComponent<Animator> ().SetBool ("Hover", true);
	}

	void OnMouseExit() {
		GetComponent<Animator> ().SetBool ("Hover", false);
	}
}
