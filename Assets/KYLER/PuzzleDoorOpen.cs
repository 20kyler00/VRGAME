using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDoorOpen : MonoBehaviour {
   public MeshRenderer light_check_one;
   public MeshRenderer light_check_two;
   public Material material;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (light_check_one.material == material&& light_check_two.material == material)
        {
            gameObject.transform.position.Set(gameObject.transform.position.x, gameObject.transform.position.y + .1f, gameObject.transform.position.z);
        }
        if (light_check_one.material == material)
        {
            Debug.Log("foo");
        }

    }
}
