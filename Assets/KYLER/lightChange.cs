using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightChange : MonoBehaviour {
    public GameObject light;
    public Material material;
    public bool one;
    // Use this for initialization
    
    public void LightChange()
    {
        light.transform.GetComponent<MeshRenderer>().material = material;
        light.GetComponentInChildren<Light>().color = new Vector4(0, 255, 0, 1);
        light.GetComponentInChildren<Light>().intensity = 3;
        if (one)
            light.GetComponentInParent<PuzzleDoorOpen>().one = true;
        if (!one)
            light.GetComponentInParent<PuzzleDoorOpen>().two = true;
    }
}
