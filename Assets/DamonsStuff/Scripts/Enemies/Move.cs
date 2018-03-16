using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    public GameObject player;
    public float moveSpeed = 1;
    public float increaseY = 1;
    public float stopRange = 10;
    public float withinRange;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPosition = player.transform.position;
        playerPosition.y += increaseY;
        Vector3 findingThings = new Vector3(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y, playerPosition.z - transform.position.z);
        withinRange = findingThings.magnitude;
        if (stopRange <= withinRange)
        {
            transform.position = Vector3.Lerp(transform.position, playerPosition, moveSpeed * Time.deltaTime);
        }
        //Debug.Log(withinRange);
    }

    public void Charge()
    {
        Vector3 playerPosition = player.transform.position;
        playerPosition.y += increaseY;
        transform.position = Vector3.Lerp(transform.position, playerPosition, moveSpeed * Time.deltaTime); 
        //GetComponent<Rigidbody>().velocity = playerPosition * moveSpeed;
    }
}
