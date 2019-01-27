using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{

    public Rigidbody2D rb;
    public Image feulBar;
    public Image HealthBar;

    public float speed = 10f;
    private float startSpeed;

    public float health = 100f;
    private float maxHealth;

    public float feul = 100f;
    private float maxFeul;
    public float feulLossRate = 5;
  
    public float rotateSpeed = 20f;

    public float maxSpeed = 50f;
    public float rocketAccelRate = 10f;
    private float timeBetweenAccel;

    public AudioSource RocketIdle;
    public AudioSource RocketAcc;


    public float boostSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        startSpeed = speed;
        maxHealth = health;
        maxFeul = feul;

        
    }

    private void Update()
    {
        if (feul <= 0)
        {
            Destroy(gameObject);
        }

        feulBar.fillAmount = feul / maxFeul;
    }


    private void FixedUpdate()
    {
 

        if (Input.GetKey("a"))
        {
            transform.Rotate(new Vector3(0f, 0f, rotateSpeed));
        }
        else if (Input.GetKey("d"))
        {
            transform.Rotate(new Vector3(0f,0f, -rotateSpeed));  
        }

        //rb.velocity = transform.up * speed;

        if (Input.GetKey(KeyCode.W))
        {
            speed += rocketAccelRate * Time.deltaTime;

            if (speed >= maxSpeed)
            {
                speed = maxSpeed;
            }

            if (!RocketIdle.isPlaying)
            {
                RocketIdle.Play();
            }

            feul -= feulLossRate * Time.deltaTime;
        }
        else
        {
            speed -= rocketAccelRate * Time.deltaTime;
            if (speed <= 0)
            {
                speed = 0;
            }
            
            RocketIdle.Stop();
        }

        if (Input.GetKey(KeyCode.S))
        {
            speed -= rocketAccelRate * Time.deltaTime;

            if (speed <= -maxSpeed)
            {
                speed = -maxSpeed;
            }
            
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = boostSpeed;
            if (!RocketAcc.isPlaying)
            {
                RocketAcc.Play();
            }

            feul -= feulLossRate * 2 * Time.deltaTime;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = startSpeed;
            RocketAcc.Stop();
        }

        if (!Input.GetKey(KeyCode.LeftShift) && RocketAcc.isPlaying)
        {
            RocketAcc.Stop();
        }

        rb.AddForce(transform.up * speed);

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Planet")
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= 20;
        HealthBar.fillAmount = health / maxHealth;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
