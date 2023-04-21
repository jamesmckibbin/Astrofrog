using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Jetpack_Pickup : MonoBehaviour
{
    [SerializeField] float duration;

    //Gives the frog a jetpack with configurable duration when they eat it.
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.gameObject.GetComponent<Scr_Jetpack_Effect>().PackinTime = true;

            StartCoroutine(col.gameObject.GetComponent<Scr_Jetpack_Effect>().JetpackStart(duration));
            print("started!");
        }
    }
}
