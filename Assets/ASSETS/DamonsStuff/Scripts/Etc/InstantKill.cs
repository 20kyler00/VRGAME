using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantKill : MonoBehaviour {
    public string killButton;
    public GameObject Billy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(killButton))
        {
            if (Billy != null)
            {
                Billy.GetComponent<Traveling>().RemoveTurret(gameObject);
                Destroy(gameObject);
            } else
            {
                Destroy(gameObject);
            }
        }
	}
}
