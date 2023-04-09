using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Projectile_Travel : MonoBehaviour
{
    //Easy travel for the projectile.
    void Update()
    {transform.position += transform.up * Time.deltaTime * 2.0f;}

    //The projectile will dissipate when it hits a wall.
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Tongueable"))
        {Destroy(this.gameObject);}
    }
}