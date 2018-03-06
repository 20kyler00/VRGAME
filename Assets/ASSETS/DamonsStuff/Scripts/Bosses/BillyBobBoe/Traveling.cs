﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traveling : MonoBehaviour {
    public GameObject[] locations;
    public float chaseSpeed = 10;
    public float fireAtWillSpeed = 5;
    private GameObject target;
    List<GameObject> turrets = new List<GameObject>();
    List<GameObject> myGuns = new List<GameObject>();
    private bool stillTurrets = true;
	// Use this for initialization
	void Start () {
        target = locations[0];
        GameObject[] addThem = GameObject.FindGameObjectsWithTag("Turret");
        //Debug.Log(addThem.Length);
        for(int i = 0; i < addThem.Length; i++)
        {
            turrets.Add(addThem[i]);
            //Debug.Log(turrets.Count);
        }
        GameObject[] addThemToo = GameObject.FindGameObjectsWithTag("Guns");
        //Debug.Log(addThem.Length);
        for (int i = 0; i < addThemToo.Length; i++)
        {
            myGuns.Add(addThemToo[i]);
            //Debug.Log(turrets.Count);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(!stillTurrets)
        {
            Vector3 position = target.transform.position;
            Vector3 chaseDirection = new Vector3(position.x - transform.position.x, position.y - transform.position.y, position.z - transform.position.z);
            GetComponent<Rigidbody>().velocity = chaseDirection * chaseSpeed;
        }
        //Debug.Log(turrets.Count);
    }

    public void RemoveTurret(GameObject turret)
    {
        GameObject removingIt;
        for(int i = 0; i < turrets.Count; i++)
        {
            if (turrets[i] == turret)
            {
                removingIt = turret;
                turrets.Remove(removingIt);
                Debug.Log(turrets.Count);
                break;
            }
        }
        if (turrets.Count == 0)
        {
            stillTurrets = false;
            for (int i = 0; i < myGuns.Count; i++)
            {
                myGuns[i].GetComponent<Firing>().shootFrequency = fireAtWillSpeed;
                
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Location")
        {
            int i = System.Array.IndexOf(locations, target) + 1;
            if (i >= locations.Length)
            {
                target = locations[0];
            } else
            {
                target = locations[i];
            }
        }
    }
}
