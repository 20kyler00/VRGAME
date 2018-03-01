using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magizine : MonoBehaviour {

    public int magcap = 30;
    int bullets;

    private void Awake()
    {
        bullets = magcap;
    }
    public void fired()
    {
        bullets -= 1;
    }
}
