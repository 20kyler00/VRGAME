using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traveling : MonoBehaviour {
    public GameObject[] locations;
    public float chaseSpeed = 10;
    private GameObject target;
    List<GameObject> turrets = new List<GameObject>();
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
        }
    }
}
