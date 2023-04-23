using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SpikyBase : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        //Hurts the frog if they touch it head-on.
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<S_PlayerHurt>().Pain();
        }

        //Also hurts the frog if they hit it with their tongue.
        else if (col.gameObject.CompareTag("Tongue"))
        {
            col.gameObject.GetComponent<S_TongueGrappling>().Retract();

            GameObject.Find("Frog").GetComponent<S_PlayerHurt>().Pain();
        }
    }
}
