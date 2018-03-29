using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public GameObject player;
    public GameObject GunnerPrefab;
    public GameObject PeaShooterPrefab;
    public GameObject TankPrefab;
    public GameObject MiniPrefab;
    public float spawnTimer = 5;
    public float timerVarience = 0.5f;
    private bool isTank = false;
    private bool isMini = false;
    private float timer = 0;
    private GameObject spawned;
    private List<GameObject> locations = new List<GameObject>();
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
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
            RandomSpawn();
            if (!isTank)
            {
                GameObject Enemy = (GameObject)Instantiate(spawned, transform.position, Quaternion.identity);
                Enemy.GetComponentInChildren<Move>().player = player;
                Enemy.GetComponentInChildren<FaceMe>().player = player;
                Component[] addThem = Enemy.GetComponentsInChildren<Firing>();
                for (int i = 0; i < addThem.Length; i++)
                {
                    addThem[i].GetComponent<Firing>().player = player;
                }
                timer = 0;
            } else
            {
                GameObject Enemy = (GameObject)Instantiate(spawned, transform.position, Quaternion.identity);
                Enemy.GetComponentInChildren<Move>().player = player;
                Enemy.GetComponentInChildren<FaceMe>().player = player;
                Enemy.GetComponentInChildren<Charge>().player = player;
                timer = 0;
            } 
            if (isMini)
            {
                GameObject MiniJoe = (GameObject)Instantiate(spawned, transform.position, Quaternion.identity);
                MiniJoe.GetComponentInChildren<MiniJoeMove>().locations = locations;
                MiniJoe.GetComponentInChildren<MiniJoeMove>().target = NewTarget();
                MiniJoe.GetComponentInChildren<Firing>().player = player;
                MiniJoe.GetComponentInChildren<FaceMe>().player = player;
                timer = 0;
            }
        }
	}

    public void RandomSpawn()
    {
        int randomize = Random.Range(0, 4);
        if (randomize == 0)
        {
            isTank = false;
            isMini = false;
            spawned = PeaShooterPrefab;
            spawnTimer -= timerVarience;
        } else if (randomize == 1)
        {
            isTank = false;
            isMini = false;
            spawned = GunnerPrefab;
            spawnTimer += timerVarience; 
        } else if (randomize == 2)
        {
            isTank = true;
            isMini = false;
            spawned = TankPrefab;
            spawnTimer += timerVarience;
        } else if ( randomize == 4)
        {
            isTank = false;
            isMini = true;
            spawned = MiniPrefab;
            spawnTimer -= timerVarience;
        }
    }
    GameObject NewTarget()
    {
        int indexLoc;
        indexLoc = Random.Range(0, locations.Count);
        return locations[indexLoc];
    }
}
