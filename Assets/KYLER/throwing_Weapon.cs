using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwing_Weapon : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!(gameObject.transform.parent == null))
        {
            if (gameObject.transform.position.magnitude - gameObject.transform.parent.transform.position.magnitude > 5)
            {
                gameObject.transform.SetParent(null);
            }
        }
    }
}
