using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Line : MonoBehaviour {
	
	public Vector3 start;
	public Vector3 end;

	LineRenderer line;

	void Start() {
		line = GetComponent<LineRenderer> ();
	}

	void Update () {
		line.positionCount = 2;
		line.SetPosition (0, transform.position + start);
		line.SetPosition (1, transform.position + end);
	}
}
