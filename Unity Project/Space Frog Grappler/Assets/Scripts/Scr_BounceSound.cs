using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Scr_BounceSound : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Tongue")) //If the player hits the object, it plays a bonk sound effect.
        {
            if (GameObject.Find("Frog").GetComponent<Rigidbody2D>().velocity.magnitude > 0.05)
            {
                GameObject.Find("AudioManager").GetComponent<AudioManager>().BonkSFX();
            }
        }
    }
}