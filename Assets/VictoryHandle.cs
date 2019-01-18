using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryHandle : MonoBehaviour {

	public GameObject victoryScreen;
	public GameObject button;
	bool once = false;
	
	// Update is called once per frame
	void Update () {
		if (FindObjectOfType<GameBoardCreator> ().GameOver && !once) {
			victoryScreen.SetActive (true);
			//victoryScreen.GetComponent<Animator> ().Play ("onEnable");
			once = true;
		}
	}

	public void EnableButton() {
		button.SetActive (true);
	}
}
