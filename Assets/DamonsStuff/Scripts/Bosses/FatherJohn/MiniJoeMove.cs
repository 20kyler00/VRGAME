using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniJoeMove : MonoBehaviour {
    public float moveTimer = 0.7f;
    public float chaseSpeed = 5;
    public List<GameObject> locations = new List<GameObject>();
    public GameObject target;
    private float timer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= moveTimer)
        {
            NewTarget();
            timer = 0;
        }
        Vector3 Position = target.transform.position;
        //Vector3 chaseDirection = new Vector3(Position.x - transform.position.x, Position.y - transform.position.y, Position.z - transform.position.z);
        //GetComponent<Rigidbody>().velocity = chaseDirection * chaseSpeed;
        transform.position = Vector3.Lerp(transform.position, Position, chaseSpeed * Time.deltaTime);
    }
    void NewTarget()
    {
        int indexLoc;
        indexLoc = Random.Range(0, locations.Count);
        target = locations[indexLoc];
    }
}
