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
            print("jetpack activated!");
            col.gameObject.GetComponent<Scr_Jetpack_Effect>().packinTime = true;
            StartCoroutine(col.gameObject.GetComponent<Scr_Jetpack_Effect>().JetpackDuration(duration));
        }
    }
}
