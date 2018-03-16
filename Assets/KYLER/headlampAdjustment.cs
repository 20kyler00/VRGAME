using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headlampAdjustment : MonoBehaviour {
    public Light HeadLamp;
    public float interval;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.Get(OVRInput.Button.Two) || Input.GetKeyDown(KeyCode.L))
        {
            HeadLamp.intensity += interval;
            if(HeadLamp.intensity >= 5)
            {
                HeadLamp.intensity = .1f;
            }
        }

    }
}
