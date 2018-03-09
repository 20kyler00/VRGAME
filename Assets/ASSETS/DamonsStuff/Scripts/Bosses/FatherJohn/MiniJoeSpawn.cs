using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniJoeSpawn : MonoBehaviour {
    public GameObject miniJoePrefab;
    public GameObject player;
    public float spawnTimer = 30;
    private float timer = 0;
    private List<GameObject> locations = new List<GameObject>();
	// Use this for initialization
	void Start () {
        GameObject[] addThem = GameObject.FindGameObjectsWithTag("Locations");
        for (int i = 0; i < addThem.Length; i++)
        {
            locations.Add(addThem[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= spawnTimer)
        {
            GameObject MiniJoe = (GameObject)Instantiate(miniJoePrefab, transform.position, Quaternion.identity);
            MiniJoe.GetComponentInChildren<MiniJoeMove>().locations = locations;
            MiniJoe.GetComponentInChildren<MiniJoeMove>().target = NewTarget();
            MiniJoe.GetComponentInChildren<Firing>().player = player;
            MiniJoe.GetComponentInChildren<FaceMe>().player = player;
            timer = 0;
        }
	}

    GameObject NewTarget()
    {
        int indexLoc;
        indexLoc = Random.Range(0, locations.Count);
        return locations[indexLoc];
    }
}
