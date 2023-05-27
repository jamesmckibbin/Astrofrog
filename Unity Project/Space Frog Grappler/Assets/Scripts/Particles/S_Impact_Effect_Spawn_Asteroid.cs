using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

//Produces a special impact effect if you collide with a wall hard enough.
//This one is used for the asteroid tileset, producing dust.
public class S_Impact_Effect_Spawn_Asteroid : MonoBehaviour
{
    [SerializeField] GameObject asteroidExplosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Tongue"))
        {
            if (GameObject.Find("Frog").GetComponent<Rigidbody2D>().velocity.magnitude > 3)
            {
                Instantiate(asteroidExplosion, new Vector3 (collision.GetContact(0).point.x, collision.GetContact(0).point.y, 0),
                new Quaternion (0.0f, 0.0f, 0.0f, 1.0f));
            }
        }
    }
}