using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaCannon : MonoBehaviour {
    public GameObject bullet;
    public GameObject player;
    public float shootFrequency = 30;
    private float shootTimer = 0;
    public float shootRange = 30;
    Vector3 playerPosition;
    Vector3 shootDirection;
    Vector3 lastPlayerPosition;
    public int shootspeed;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        shootTimer += Time.deltaTime;
        Vector3 playerPosition = player.transform.position;
        Vector3 shootDirection = new Vector3(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y, playerPosition.z - transform.position.z);
        
        if (shootTimer >= shootFrequency)
        {
            lastPlayerPosition = new Vector3(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y, playerPosition.z - transform.position.z);
            shootTimer = 0;
            //Debug.Log("Pew");
            lastPlayerPosition.Normalize();
            //Debug.Log("x direction = " + lastPlayerPosition.x + " and y direction = " + lastPlayerPosition.y + " and z direction = " + lastPlayerPosition.z);
            playerPosition.x += lastPlayerPosition.x * shootRange;
            playerPosition.y += lastPlayerPosition.y * shootRange;
            playerPosition.z += lastPlayerPosition.z * shootRange;
            Vector3 shootingPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            GameObject MegaBullet = (GameObject)Instantiate(bullet, shootingPosition, Quaternion.identity);
            MegaBullet.GetComponent<Rigidbody>().velocity = lastPlayerPosition * shootspeed;
        }
	}
}
