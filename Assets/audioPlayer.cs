using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPlayer : MonoBehaviour {

	public void PlaySound(AudioClip cl, float time, bool loop = false) {
		GetComponent<AudioSource> ().clip = cl;
		GetComponent<AudioSource> ().loop = loop;
		//GetComponent<AudioSource> ().playOnAwake = false; 
		GetComponent<AudioSource> ().Play ();
		if (!loop)
			Destroy (this.gameObject, time);
	}

}
