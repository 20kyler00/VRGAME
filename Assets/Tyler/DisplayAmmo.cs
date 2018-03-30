using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayAmmo : MonoBehaviour {

	int currentAmmo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		currentAmmo = PlayerPrefs.GetInt ("Bullets");
		gameObject.GetComponent<Text> ().text = "" + currentAmmo + " / 30";
	}
}
