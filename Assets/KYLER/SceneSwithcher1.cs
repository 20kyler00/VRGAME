using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HealthSceneSwithcher : MonoBehaviour {
    public GameObject boss;
    public string SceneToLoad = "";
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void up
    {
        
    


    SceneManager.LoadScene(SceneToLoad);
        
	}
}
