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
            int damage = collision.gameObject.GetComponent<Damage>().damage;
            Ouch(damage);
            Destroy(collision.gameObject);
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Bullet")
        {
            int damage = hit.gameObject.GetComponent<Damage>().damage;
            Ouch(damage);
            Destroy(hit.gameObject);
        } else if (hit.gameObject.tag == "Tank")
        {
            Debug.Log("Oof");
            Ouch(1);
            hit.gameObject.GetComponent<Charge>().Boop();
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
                SceneManager.LoadScene("Lose");
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
            } else if (specialType == "BB")
            {
                SceneManager.LoadScene("JoeArena");
            } else if (specialType == "Joe")
            {
                SceneManager.LoadScene("BobArena");
            } else if (specialType == "Bob")
            {
                SceneManager.LoadScene("JohnArena");
            } else if (specialType == "John")
            {
                SceneManager.LoadScene("Win");
            }
        }
    }

	public int getHealth ()
	{
		return health;
	}
}
