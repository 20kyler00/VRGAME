using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {
    public int health = 10;
    public bool isSpecial = false;
    public string specialType;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Ouch(1);
            Destroy(collision.gameObject);
        }
    }
    void Ouch(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (!isSpecial)
            {
                Debug.Log("Poof");
                Destroy(gameObject);
            } else if (specialType == "Player")
            {

            } else if (specialType == "Turret")
            {
                GetComponent<InstantKill>().RemoveIt();
                Destroy(gameObject);
            } else if (specialType == "Arm")
            {
                GameObject.Find("BBHead").GetComponent<Health>().Ouch(100);
                GameObject.Find("BBHead").GetComponentInChildren<Firing>().bulletFrequency = GameObject.Find("BBHead").GetComponentInChildren<Firing>().bulletFrequency / 2;
                GameObject.Find("BBHead").GetComponentInChildren<Firing>().shootFrequency = GameObject.Find("BBHead").GetComponentInChildren<Firing>().shootFrequency / 2;
                Destroy(gameObject);
            }
        }
    }
}
