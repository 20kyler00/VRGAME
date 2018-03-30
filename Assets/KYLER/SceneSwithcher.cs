using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwithcher : MonoBehaviour {

    public string SceneToLoad = "";
    public GameObject smack;
	// Use this for initialization
	void Start () {
		
	}

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.name == smack.name)
        {
            SceneManager.LoadScene(SceneToLoad);
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        
    


    SceneManager.LoadScene(SceneToLoad);
        
	}
}
