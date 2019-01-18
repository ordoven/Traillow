using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[System.Serializable]
public class GameBoardCreator : MonoBehaviour {

	public GameObject node;
	[Space]
	public Vector3 start;
	public Vector3 end;
	public Vector3 pradzia;
	public Vector3 pabaiga;
	[Space]
	public Color praSpalva;
	public Color pabSpalva;
	public Color idleSpalva;
	[Space]
	public GameObject Sound;
	public AudioClip aud;
	Vector3 oldStart, oldEnd;

	public bool GameOver = false;

	void Start() {
		var obj = Instantiate (Sound);
		obj.GetComponent<audioPlayer> ().PlaySound (aud, 999999999, true);
	}

	public void RemoveBoard() {
		int childs = transform.childCount;
		for (int i = childs - 1; i >= 0; i--) {
			Destroy (transform.GetChild(i).gameObject);
		}
	}

	public void CreateBoard() {
		for (float y = start.y; y < end.y; y++) {
			for (float x = start.x; x < end.x; x++) {
				var obj = Instantiate (node, new Vector3 (x, y, 0), Quaternion.identity);
				if (pradzia.x == x && pradzia.y == y) {
					obj.name = "Start";
					obj.tag = "Start";
					obj.GetComponent<Node> ().col = praSpalva;
				} else if (pabaiga.x == x && pabaiga.y == y) {
					obj.name = "End";
					obj.tag = "End";
					obj.GetComponent<Node> ().col = pabSpalva;
				} else {
					obj.name = "Standard Node";
					obj.tag = "Object";
					obj.GetComponent<Node> ().col = idleSpalva;
				}
				obj.transform.SetParent (transform);
			}
		}
	}

	void Recolor(GameObject obj, Color col) {
		foreach (Transform ting in obj.transform) {
			ting.GetComponent<SpriteRenderer> ().color = col;
		}
	}

	public void Nulinimas() {
		foreach(Transform child in transform) {
			foreach (Transform ch in child.GetChild(1)) {
				ch.gameObject.SetActive (false);
			}
		}
	}

	public bool CheckForVictory () {
		int suma = 0;
		for (float i = start.y; i < end.y; i++) {
			foreach (Transform obj in transform) {
				if (obj.position.y == i && obj.GetComponent<Node> ().occupied) {
					suma++;
					break;
				}
			}
		}
		if ((Math.Abs (start.y - end.y) == suma || Math.Abs (start.y - end.y) == suma + 1) && (Restriction (new Vector3 (pabaiga.x - 1, pabaiga.y, pabaiga.z)) || Restriction (new Vector3 (pabaiga.x, pabaiga.y - 1, pabaiga.z))) && FindObjectOfType<score> ().scr == FindObjectOfType<score> ().total) {
			GameOver = true;
			return GameOver;	
		}

		else
			return false;
	}


	bool Restriction (Vector3 location) {
		foreach (Transform obj in transform) {
			if (obj.position == location && obj.GetComponent<Node>().occupied) {
				return true;
			}
		}
		return false;
	}
}
