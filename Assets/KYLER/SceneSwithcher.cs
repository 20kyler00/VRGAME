using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwithcher : MonoBehaviour {

    public string SceneToLoad = "";
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        
    


    SceneManager.LoadScene(SceneToLoad);
        
	}
}
