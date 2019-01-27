using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wormhole : MonoBehaviour
{
    public GameObject OtherPortal;
    public GameObject Player;
    public static float WormholeTimer = 0f;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (WormholeTimer == 0)
        {
            WormholeTimer = 10.0f;
            StartCoroutine(Teleport());
        }
        
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(0.5f);
        Player.transform.position = new Vector2(OtherPortal.transform.position.x, OtherPortal.transform.position.y);
    }

    private void Update()
    {
        if (WormholeTimer != 0)
        {
            WormholeTimer -= Time.deltaTime;
        }
        if (WormholeTimer < 0) WormholeTimer = 0f;
    }


}
