using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Spiky_Base : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        //Hurts the frog if they touch it head-on.
        if (col.gameObject.CompareTag("Player"))
        {col.gameObject.GetComponent<Scr_Frog_Hurt>().Pain();}

        //Also hurts the frog if they hit it with their tongue.
        else if (col.gameObject.CompareTag("Tongue"))
        {
            col.gameObject.GetComponent<Scr_Tongue_Grappling>().Retract();

            col.gameObject.transform.parent.GetComponent<Scr_Frog_Hurt>().Pain();
        }
    }
}
