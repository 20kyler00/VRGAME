using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour {
    public GameObject player;
    public float stunTime = 3;
    private bool stunned = false;
    private float stunTimer = 0;
    private float speed;
    private float originalSpeed;
    private float stopRange;
	// Use this for initialization
	void Start () {
        originalSpeed = GetComponent<Move>().moveSpeed;
        speed = originalSpeed * 4;
        stopRange = GetComponent<Move>().stopRange;
	}
	
	// Update is called once per frame
	void Update () {
        if (stunned)
        {
            stunTimer += Time.deltaTime;
            if (stunTimer >= stunTime)
            {
                stunned = false;
                GetComponent<Move>().moveSpeed = originalSpeed;
                stunTimer = 0;
            }
        }
		else if (GetComponent<Move>().withinRange <= stopRange)
        {
            GetComponent<Move>().moveSpeed = speed;
            GetComponent<Move>().Charge();
        }
	}

    public void Boop()
    {
        GetComponent<Move>().moveSpeed = 0;
        stunned = true;
    }
    
}
