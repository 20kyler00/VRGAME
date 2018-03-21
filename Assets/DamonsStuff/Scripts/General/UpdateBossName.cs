using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateBossName : MonoBehaviour {
    public string name;
	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = name;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
