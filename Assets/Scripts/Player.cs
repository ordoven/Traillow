using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed;
	GameObject[] Objects;
	LineRenderer lineR;
	//public int lastPos = -1; // 0 - desine, 1 - kaire, 2 - virsus, 3 - apacia;

	// Use this for initialization
	void Start () {
		Objects = GameObject.FindGameObjectsWithTag ("Object");
		lineR = GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetMouseButton (0)) {
			// Animation Plays ();
			InputHandle ();
			// Smooth movement:
			// gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, pz, speed);
		} else {
			lineR.positionCount = 1;
			lineR.SetPosition(lineR.positionCount-1, transform.position);
		}

	}

	void InputHandle() {
		Vector3 pz = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		pz.z = 0;
		if (Mathf.Floor (pz.x) > gameObject.transform.position.x) {
			//foreach (var obj in Objects) {
			//	if (obj.transform.position == new Vector3 (transform.position.x + 1, transform.position.y, 0f))
			//		return;
			//}
			transform.position = new Vector3 (transform.position.x + 1, transform.position.y, 0f);
			if (lineR.GetPosition (lineR.positionCount - 2) == transform.position) {
				lineR.positionCount -= 2;
			} else {
				lineR.positionCount++;
				lineR.SetPosition (lineR.positionCount - 1, transform.position);
			}

		} else if (Mathf.Floor (pz.x) < gameObject.transform.position.x) {
			//foreach (var obj in Objects) {
			//	if (obj.transform.position == new Vector3 (transform.position.x - 1, transform.position.y, 0f))
			//		return;
			//}
			transform.position = new Vector3 (transform.position.x - 1, transform.position.y, 0f);
			if (lineR.GetPosition (lineR.positionCount - 2) == transform.position) {
				lineR.positionCount -= 2;
			} else {
				lineR.positionCount++;
				lineR.SetPosition (lineR.positionCount - 1, transform.position);
			}
		} else if (Mathf.Floor (pz.y) > gameObject.transform.position.y) {
			//foreach (var obj in Objects) {
			//	if (obj.transform.position == new Vector3 (transform.position.x, transform.position.y + 1, 0f))
			//		return;

			transform.position = new Vector3 (transform.position.x, transform.position.y + 1, 0f);
			if (lineR.GetPosition (lineR.positionCount - 2) == transform.position) {
				lineR.positionCount -= 2;
			} else {
				lineR.positionCount++;
				lineR.SetPosition (lineR.positionCount - 1, transform.position);
			}
		} else if (Mathf.Floor (pz.y) < gameObject.transform.position.y) {
			foreach (var obj in Objects) {
				if (obj.transform.position == new Vector3 (transform.position.x, transform.position.y - 1, 0f))
					return;
			}
			transform.position = new Vector3(transform.position.x, transform.position.y-1, 0f);
			if (lineR.GetPosition(lineR.positionCount-2) == transform.position) {
				lineR.positionCount-=2;
			} else {
				lineR.positionCount++;
				lineR.SetPosition(lineR.positionCount-1, transform.position);
			}
		}
	}
}
