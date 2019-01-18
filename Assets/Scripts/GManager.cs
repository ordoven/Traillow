using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour {

	public List<GameObject> nodes;
	public GameObject board;

	void Start() {
		board.GetComponent<GameBoardCreator> ().RemoveBoard ();
		board.GetComponent<GameBoardCreator> ().CreateBoard ();
	}
		
}
