using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Fly_Base : MonoBehaviour
{
    private bool grabbed = false;
    Transform tongue;

    void Update()
    {
        if (grabbed)
        {transform.position = tongue.position;}
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Tongue")
        grabbed = true;
        tongue = col.transform;

        if (col.tag == "Player")
        {Destroy(this.gameObject);}
    }
}