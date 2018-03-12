using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightChange : MonoBehaviour {
    public GameObject light;
    public Material material;
    // Use this for initialization
    
    public void LightChange()
    {
        light.transform.GetComponent<MeshRenderer>().material = material;

    }
}
