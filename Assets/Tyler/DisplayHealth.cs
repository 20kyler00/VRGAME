using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour 
{
	public GameObject player;
	int health;
	int maxHealth;

	// Use this for initialization
	void Start () {
		maxHealth = player.GetComponent<Health> ().getHealth();
	}
	
	// Update is called once per frame
	void Update () {
		health = player.GetComponent<Health> ().getHealth();
		gameObject.GetComponent<Text> ().text = "" + health + " / " + maxHealth;
	}
}
