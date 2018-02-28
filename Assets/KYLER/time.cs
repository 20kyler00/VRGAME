using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time : MonoBehaviour {
    bool is_slow = false;
    float time_countdown = 5;
    public float time_speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(is_slow)
        {
            time_countdown -= Time.deltaTime;
        }
        else if(time_countdown < 5)
        {
            time_countdown += Time.deltaTime;
        }
        if(time_countdown < 0)
        {
            is_slow = false;
            Time.timeScale = 1;
        }
        if (OVRInput.Get(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.Q))
        {
            is_slow = true;
            Time.timeScale = time_speed;
        }
	}
    
}
