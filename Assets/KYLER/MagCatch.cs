using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagCatch : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Gun")
        {

            gameObject.transform.SetParent(collision.gameObject.transform.parent.transform);
            gameObject.transform.position.Set(0.02336943f, 0.5343627f, -0.967316f);
        }
    }
}
