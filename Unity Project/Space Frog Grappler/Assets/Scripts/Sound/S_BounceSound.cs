using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class S_BounceSound : MonoBehaviour
{
    Animator animator;
    public float frogRot = 0;

    void Start()
    {
        animator = GameObject.Find("Frog").GetComponent<Animator>();

        animator.SetBool("HitWall", false);
    }

    void FixedUpdate()
    {
       frogRot = GameObject.Find("Frog").GetComponent<Rigidbody2D>().transform.rotation.z;

       animator.SetFloat("FrogRotation", frogRot);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Tongue")) //If the player hits the object, it plays a bonk sound effect.
        {
            if (GameObject.Find("Frog").GetComponent<Rigidbody2D>().velocity.magnitude > 0.1)
            {
                GameObject.Find("AudioManager").GetComponent<S_AudioManager>().BonkSFX();
                animator.SetBool("HitWall", true);

                StartCoroutine(Wait());
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("HitWall", false);
    }
}
