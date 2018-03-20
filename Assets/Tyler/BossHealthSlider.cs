using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHealthSlider : MonoBehaviour {

	public GameObject boss;
	public Slider bossHealth;

	int maxHealth;
	int currentHealth;
	// Use this for initialization
	void Start () 
	{
		maxHealth = boss.GetComponent<Health> ().getHealth();
		// set slider maxValue to the boss max health
		bossHealth.maxValue = maxHealth;
		// set slider value to boss current health
		bossHealth.value = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		currentHealth = boss.GetComponent<Health> ().getHealth();
		// set slider value to boss current health
		bossHealth.value = currentHealth;
	}
}
