using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMe : MonoBehaviour {
    public GameObject player;
    public bool isTurret = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isTurret)
        {
            transform.LookAt(player.transform.position);
        } else
        {
            Vector3 playerPosition = player.transform.position;
            Vector3 whereToRotate = new Vector3(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y, playerPosition.z - transform.position.z);
            //whereToRotate.Normalize();
            Quaternion following = new Quaternion(whereToRotate.x, 0, whereToRotate.z, 0);
            transform.rotation = following;
        }
    }
}
