﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvlSelect : MonoBehaviour {

	public void LoadLevel(string name) {
		SceneManager.LoadScene (name);
	} 
}
