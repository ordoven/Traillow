using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

	Animator anim;
	public Color col;
	public List<GameObject> objektai;
	public bool occupied = false;
	void Start() {
		anim = GetComponent<Animator> ();
	}

	void LateUpdate() {
		foreach (Transform obj in transform.GetChild(0).transform) {
			obj.gameObject.GetComponent<SpriteRenderer> ().color = col;
		}
	}

	void OnMouseEnter() {
		if (!FindObjectOfType<GameBoardCreator> ().GameOver)
			anim.SetBool ("Hover", true);
	}

	void OnMouseOver() {
		if (!FindObjectOfType<GameBoardCreator> ().GameOver) {
			anim.SetBool ("Hover", true);
			Apdorojimas ();
			if (transform.parent.GetComponent<GameBoardCreator> ().CheckForVictory ()) {
				print ("Victory");
			}
		}

	}
	void OnMouseExit() {
		anim.SetBool ("Hover", false);
	}

	void Apdorojimas() {
		if (Input.GetMouseButtonDown (0)) {
			int law1 = Restriction (new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z))
				+ Restriction (new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z));
			int law2 = Restriction (new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z))
				+ Restriction (new Vector3 (transform.position.x, transform.position.y - 1, transform.position.z));

			if (law1 == 0 && law2 == 0) {
				foreach (GameObject obj in objektai) {
					obj.SetActive (false);
				}
				occupied = false;

				return;
			}

			for (int i = 0; i < objektai.Count; i++) {
				if (objektai [i].activeSelf) {
					if (i + 1 == objektai.Count) {
						if ((law1 == 2 || law2 == 2) || (law1 == 1 && law2 == 1)) {
							FindObjectOfType<score> ().UpdateScore (-objektai [i].GetComponent<objektas> ().varzosKiekis);
							objektai [i].SetActive (false);
							objektai [0].SetActive (true);
							FindObjectOfType<score> ().UpdateScore (objektai [0].GetComponent<objektas> ().varzosKiekis);
							occupied = true;
						} else {
							print ("pradzia");
							foreach (GameObject obj in objektai) {
								if (obj.activeSelf)
									FindObjectOfType<score> ().UpdateScore (-obj.GetComponent<objektas> ().varzosKiekis);
								obj.SetActive (false);
								occupied = false;
							}
						} 
						return;
					} else {
						FindObjectOfType<score> ().UpdateScore (-objektai [i].GetComponent<objektas> ().varzosKiekis);
						objektai [i].SetActive (false);
						objektai [i + 1].SetActive (true);
						FindObjectOfType<score> ().UpdateScore (objektai [i + 1].GetComponent<objektas> ().varzosKiekis);
						occupied = true;
					}
					return;
				}
			} 

			occupied = true;
			objektai [0].SetActive (true);

			FindObjectOfType<score> ().UpdateScore (objektai [0].GetComponent<objektas> ().varzosKiekis);
		}

	}



	int Restriction (Vector3 location) {
		foreach (Transform obj in transform.parent) {
			if (obj.position == location) {
				foreach (Transform ob in obj.GetChild(1).transform) {
					if (ob.gameObject.activeSelf || (obj.tag == "Start"))
						return 1;
				}
			}
		}
		return 0;
	}
		
}
