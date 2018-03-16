using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncing : MonoBehaviour {
    public float moveTimer = 0.7f;
    public float spinAttackCountDown = 30;
    public float spinDuration = 30;
    public GameObject middle;
    public GameObject[] locations;
    public float chaseSpeed = 5;
    public float howClose = 3;
    public bool isSpinning;
    

    private GameObject target;
    private float timer;
    private float spinTimer;
    private float spinningTimer;
    
	// Use this for initialization
	void Start () {
        target = locations[0];
        isSpinning = false;
	}
	
	// Update is called once per frame
	void Update () {
        spinTimer += Time.deltaTime;
        timer += Time.deltaTime;

        if (spinTimer >= spinAttackCountDown)
        {
            spinningTimer += Time.deltaTime;
            target = middle;
            Vector3 tempPos = target.transform.position;
            Vector3 howClose = new Vector3(tempPos.x - transform.position.x, tempPos.y - transform.position.y, tempPos.z - transform.position.z);
            float closeness = howClose.magnitude;
            if (closeness <= 3)
            {
                isSpinning = true;
                transform.Rotate(new Vector3(0, 0, 1000 * Time.deltaTime));
                if (spinningTimer >= spinDuration)
                {
                    isSpinning = false;
                    spinningTimer = 0;
                    spinTimer = 0;
                    timer = 0;
                    NewTarget();
                }
            }
        }
        else if (timer >= moveTimer)
        {
            NewTarget();
            timer = 0;
        }
        Vector3 position = target.transform.position;
        /*Vector3 chaseDirection = new Vector3(position.x - transform.position.x, position.y - transform.position.y, position.z - transform.position.z);
        GetComponent<Rigidbody>().velocity = chaseDirection * chaseSpeed;*/
        transform.position = Vector3.Lerp(transform.position, position, chaseSpeed * Time.deltaTime);
    }

    void NewTarget()
    {
        int indexLoc;
        indexLoc = Random.Range(0, locations.Length);
        target = locations[indexLoc];
    }
}
