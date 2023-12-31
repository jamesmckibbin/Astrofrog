using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_JetpackPickup : MonoBehaviour
{
    //Labelling the duration as "duration1, 2, 3" because getting configurable durations is a three-leg journey
    [SerializeField] float duration1;

    //Gives the frog a jetpack with configurable duration when they eat it.
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.gameObject.GetComponent<S_JetpackEffect>().PackinTime = true;

            col.gameObject.GetComponent<S_JetpackEffect>().JetpackStart(duration1);
        }
    }
}
