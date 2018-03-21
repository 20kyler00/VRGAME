using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightPulse : MonoBehaviour {
    float intensity ;
    bool up = true;
    public float range;
    public float size;
	// Use this for initialization
	void Start () {
        intensity = gameObject.GetComponent<Light>().intensity;
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.GetComponent<Light>().intensity <= intensity + range&& gameObject.GetComponent<Light>().intensity >= intensity && up || gameObject.GetComponent<Light>().intensity ==0) {

            //gameObject.GetComponent<Light>().intensity += .1f;
            up = true;
                }
        else if(gameObject.GetComponent<Light>().intensity >= intensity + range)
        {
            //gameObject.GetComponent<Light>().intensity -= .1f;
            up = false;
        }

        if (up)
        {
            gameObject.GetComponent<Light>().intensity += size;
        }
        if (!up)
        {
            gameObject.GetComponent<Light>().intensity -= size;
        }
	}
}
