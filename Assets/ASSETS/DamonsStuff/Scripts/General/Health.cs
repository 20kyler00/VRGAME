using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public int health = 10;
    public bool isPlayer = false;
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

        }
    }
    void Ouch(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (!isPlayer)
            {
                Destroy(gameObject);
            }
        }
    }
}
