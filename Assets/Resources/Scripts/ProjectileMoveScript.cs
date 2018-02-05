using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class ProjectileMoveScript : MonoBehaviour {

	public float speed;
	public GameObject explosionPrefab;

	void Update () {		
		transform.position += new Vector3 (0, 0, speed*Time.deltaTime);
	}

	void OnCollisionEnter (Collision co) {
		if(co.gameObject.tag == "Enemy"){

			speed = 0;
			GetComponent<Rigidbody> ().isKinematic = true;

			ContactPoint contact = co.contacts [0];
			Quaternion rot = Quaternion.FromToRotation (Vector3.up, contact.normal);
			Vector3 pos = contact.point;

			Instantiate (explosionPrefab, pos, rot);

			StartCoroutine (DestroyParticle(1f));
		}
	}

	public IEnumerator DestroyParticle (float waitTime) {

		List<Transform> tList = new List<Transform> ();

		foreach (Transform t in transform.GetChild(0).transform) {
			tList.Add (t);
		}

		while (transform.GetChild(0).localScale.x > 0) {
			yield return new WaitForSeconds (0.01f);
			transform.GetChild(0).localScale -= new Vector3 (0.1f, 0.1f, 0.1f);
			for (int i = 0; i < tList.Count; i++) {
				tList[i].localScale -= new Vector3 (0.1f, 0.1f, 0.1f);
			}
		}
		
		yield return new WaitForSeconds (waitTime);
		Destroy (gameObject);
	}


}
