using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour 
{
	int health;
	int maxHealth;

	// Use this for initialization
	void Start () 
	{
		maxHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health> ().getHealth();
	}
	
	// Update is called once per frame
	void Update () 
	{
		health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health> ().getHealth();
		gameObject.GetComponent<Text> ().text = "" + health + " / " + maxHealth;
	}
}
