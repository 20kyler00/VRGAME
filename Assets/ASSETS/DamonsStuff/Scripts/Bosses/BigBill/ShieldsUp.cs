using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldsUp : MonoBehaviour {
    public GameObject protect;
    public GameObject attack;
    public float defending = 10;
    public float attacking = 5;
    public float moveSpeed = 5;
    private bool moving;
    private bool stance;
    float shooting;
    float timer = 0;
	// Use this for initialization
	void Start () {
        shooting = defending;
	}
	
	// Update is called once per frame
	void Update () {
        if (!moving)
        {
            timer += Time.deltaTime;
            if (timer >= shooting)
            {
                MovingTheMove();
            }
        } else
        {
            MovingTheMove();
        }
	}

    void MovingTheMove()
    {
        if (!moving)
        {
            moving = true;
        }
        if (!stance)
        {
            Debug.Log("Moving to Attack");
            timer = 0;
            //if stance == false, BB is firing
            Vector3 position = attack.transform.position;
            Vector3 moveDirection = new Vector3(position.x - transform.position.x, position.y - transform.position.y, position.z - transform.position.z);
            GetComponent<Rigidbody>().velocity = moveDirection * moveSpeed; 
        } else if (stance)
        {
            timer = 0;
            //if stance == true, BB is not firing
            Vector3 position = protect.transform.position;
            Vector3 moveDirection = new Vector3(position.x - transform.position.x, position.y - transform.position.y, position.z - transform.position.z);
            GetComponent<Rigidbody>().velocity = moveDirection * moveSpeed;
            Debug.Log("Moving to Protect");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == protect.name)
        {
            Debug.Log("Protecting");
            stance = false;
            moving = false;
            GetComponent<Rigidbody>().velocity = new Vector3 (0, 0, 0);

        } else if (other.name == attack.name)
        {
            Debug.Log("Free to Attack");
            stance = true;
            moving = false;
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
