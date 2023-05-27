using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class S_Impact_Effect_Spawn : MonoBehaviour
{
    [SerializeField] GameObject asteroidExplosion;
    [SerializeField] GameObject shipExplosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Tongue")) //If the player hits the object, it plays a bonk sound effect.
        {
            if (GameObject.Find("Frog").GetComponent<Rigidbody2D>().velocity.magnitude > 0.1)
            {
                Instantiate(asteroidExplosion, new Vector3 (collision.GetContact(0).point.x, collision.GetContact(0).point.y, 0),
                new Quaternion (0.0f, 0.0f, 0.0f, 1.0f));
            }
        }
    }
}