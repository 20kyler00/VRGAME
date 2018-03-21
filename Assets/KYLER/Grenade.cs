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
    public float radius = 5.0F;
    public float power = 10.0F;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Start()
    {
        
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
        if (timer >= 5 && !exploded)
        {
            Explosion.Play();
            GetComponentInChildren<ParticleSystem>().Play();
            exploded = true;
            gameObject.GetComponentInParent<Rigidbody>().AddExplosionForce(5, new Vector3(0, 0, 0), 8);
            Debug.Log(gameObject.transform.position.magnitude - player.transform.position.magnitude);


            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

            foreach (Collider hit in colliders)
            {
                if (hit.transform.tag == "Box"|| hit.transform.tag == "lid")
                {
                    Rigidbody rb = hit.GetComponent<Rigidbody>();

                    if (rb != null)
                        rb.isKinematic = false;
                    rb.useGravity = true;
                    rb.AddExplosionForce(power, explosionPos, radius, 1.0F);
                    Debug.Log(colliders.Length + "collisions");
                }
            }
        }
    }
    public void pinPulled()
    {
        
        Pin.Play();
        pinpulled = true;
        
    }

}
