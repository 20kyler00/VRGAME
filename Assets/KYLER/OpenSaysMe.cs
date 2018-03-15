using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSaysMe : MonoBehaviour {
    public bool is_crowbar;
    public bool is_key;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (is_key)
        {
            collision.rigidbody.AddForce((gameObject.transform.position.normalized - collision.transform.position.normalized)*5,ForceMode.Impulse);

        }
        if (is_crowbar && collision.transform.tag == "lid")
        {
            collision.rigidbody.isKinematic = false;
        }
    }
}
