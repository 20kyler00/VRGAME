using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAtWill : MonoBehaviour {
    public GameObject bulletPrefab;
    public GameObject head;
    public float bulletSpeed = 5;
    public float shootFrequency = 30;
    private float shootTimer = 0;
    private float shootOG;
    // Use this for initialization
    void Start () {
        shootOG = shootFrequency;
	}
	
	// Update is called once per frame
	void Update () {
        shootTimer += Time.deltaTime;
        bool isSpinning = head.GetComponent<Bouncing>().isSpinning;
        if (isSpinning)
        {
            shootFrequency = 0.7f;
        }
        else
        {
            shootFrequency = shootOG;
        }
        if (shootTimer >= shootFrequency)
        {
            Vector3 shootDirection = transform.forward;//new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
            shootDirection = new Vector3(shootDirection.x, shootDirection.y - 0.3f, shootDirection.z);
            GameObject Bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Bullet.GetComponent<Rigidbody>().velocity = shootDirection * bulletSpeed;
            shootTimer = 0;
        }
	}
}
