using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantKill : MonoBehaviour {
    public string killButton;
    public GameObject Billy;
	// Use this for initialization
	void Start () {
		if (killButton != null)
        {
            killButton = killButton.ToLower();
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(killButton))
        {
            if (Billy != null)
            {
                RemoveIt();
                Destroy(gameObject);
            } else
            {
                Destroy(gameObject);
            }
        }
	}

    public void RemoveIt()
    {
        Billy.GetComponent<Traveling>().RemoveTurret(gameObject);
    }
}
