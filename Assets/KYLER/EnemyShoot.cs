using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {
	public GameObject prefab;
	public float bulletspeed = 10f;
	float totaltime = 0f;
	public float shootdelay = 3.0f;
	public float Engagedistance = 10.0f;
	public GameObject target;
	int clip = 30;
	float reload = 0;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		totaltime += Time.deltaTime;

		Vector2 shootd = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y);
		if (shootd.magnitude <= Engagedistance && totaltime >= shootdelay && clip > 0) {
			shootd.Normalize ();
			Vector3 spawnPosition = transform.position;
			spawnPosition.x += shootd.x * .4f;
			spawnPosition.y += shootd.y * .4f;
			GameObject bullet = (GameObject)Instantiate (prefab, spawnPosition, Quaternion.identity);
			//apply velocity
			bullet.GetComponent<Rigidbody2D> ().velocity = shootd * bulletspeed;
			Destroy (bullet, 1.0f);
			totaltime = 0;
			clip--;
		}
		else if (clip == 0) {
			reload += Time.deltaTime;
			if (reload >= 4) {
				clip = 30;

			}
	}
}
}