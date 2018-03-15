using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {
    public GameObject Lid;
    
    public bool pinpulled = false;
    public float timer = 0;
    bool exploded = false;
    bool is_already_dead;
    public AudioSource Pin;
    public AudioSource Explosion;
    GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (Lid.gameObject.transform.position.magnitude - gameObject.transform.position.magnitude > .1f && !pinpulled)
        {
            pinPulled();
        }
        if (pinpulled)
        {
            timer += Time.deltaTime;
        }
        if(timer >= 5&& !exploded)
        {
            Explosion.Play();
            GetComponentInChildren<ParticleSystem>().Play();
            exploded = true;
        }
    }
    public void pinPulled()
    {
        
        Pin.Play();
        pinpulled = true;
        
    }

}
