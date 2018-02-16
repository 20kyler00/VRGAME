using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour {
    public GameObject bulletPrefab;
    public GameObject player;
    public float bulletFrequency = 5;
    public float shootFrequency = 30;
    public int bulletAmount = 5;
    private int bulletSum = 0;
    private float shootTimer = 0;
    float bulletTimer = 0;
    public float shootRange = 30;
    private Vector3 playerPosition;
    private Vector3 shootDirection;
    public int shootspeed;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootFrequency)
        {
            bulletTimer += Time.deltaTime;
            if (bulletTimer >= bulletFrequency)
            {
                Vector3 playerPosition = player.transform.position;
                Vector3 shootDirection = new Vector3(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y, playerPosition.z - transform.position.z);
                shootDirection.Normalize();
                Vector3 shootingPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                GameObject Bullet = (GameObject)Instantiate(bulletPrefab, shootingPosition, Quaternion.identity);
                Bullet.GetComponent<Rigidbody>().velocity = shootDirection * shootspeed;
                bulletSum++;
                bulletTimer = 0;
                if (bulletSum >= bulletAmount)
                {
                    bulletSum = 0;
                    shootTimer = 0;
                }
            }
        }
    }
}
