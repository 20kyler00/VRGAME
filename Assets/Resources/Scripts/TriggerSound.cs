using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour {

	public AudioClip soundFX;

	void OnTriggerEnter (Collider co) {
		if(co.tag == "Player")
			GetComponent<AudioSource> ().PlayOneShot (soundFX);
	}
}
