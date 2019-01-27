using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;

    public GameObject abductLaserPrefab;

    public GameObject laserPrefab;

    public float range = 10f;
    public float fireRate = .25f;
    private float nextFire = 0f;
    
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            Abduct();
        }
        if (Input.GetKeyDown(KeyCode.L) && Time.time > nextFire)
        {
            nextFire = fireRate + Time.time;
            Shoot();
        }
    }

    void Abduct()
    {
        Debug.Log("Abducting");
        Debug.DrawRay(firePoint.position,firePoint.up,Color.green);
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up);
        if (hitInfo)
        {
            Debug.Log(hitInfo.transform.name);
        }
        
    }

    void Shoot()
    {
        Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
    }
}
