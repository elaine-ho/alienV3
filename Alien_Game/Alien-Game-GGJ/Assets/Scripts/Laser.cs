using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Planet planet = hitInfo.GetComponent<Planet>();
        //Asteroid asteroid = hitInfo.GetCompnent<Asteroid>();
        //if (planet != null)
        //{
        //   planet.TakeDamage();
        //}

        //if (asteroid != null)
        //{
        //     asteroid.Die();
        //}
        
        Destroy(gameObject);
    }
}
