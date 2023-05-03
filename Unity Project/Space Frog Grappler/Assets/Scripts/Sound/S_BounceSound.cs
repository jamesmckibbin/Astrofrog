using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class S_BounceSound : MonoBehaviour
{
    Animator animator;
    public float frogRot = 0;

    public float bouncy;
    public PhysicsMaterial2D bounce;
    public PhysicsMaterial2D noBounce;
    public PhysicsMaterial2D normal;
    public Collider2D col;


    void Start()
    {
        animator = GameObject.Find("Frog").GetComponent<Animator>();
        animator.SetBool("HitWall", false);

        bouncy = GameObject.Find("FrogManager").GetComponent<S_FrogManager>().bouncy;
    }

    void FixedUpdate()
    {
       frogRot = GameObject.Find("Frog").GetComponent<Rigidbody2D>().transform.rotation.z;

       animator.SetFloat("FrogRotation", frogRot);

        if (bouncy == 0.4f)
        {
            print(bouncy);
            col.sharedMaterial = normal;
        }
        else if (bouncy == 0.9f)
        {
            print(bouncy);
            col.sharedMaterial = bounce;
        }
        else if (bouncy == 0.1f)
        {
            print(bouncy);
            col.sharedMaterial = noBounce;
        }
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
