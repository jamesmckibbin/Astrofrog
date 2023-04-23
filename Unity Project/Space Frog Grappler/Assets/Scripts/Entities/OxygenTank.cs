using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenTank : MonoBehaviour
{
    [SerializeField] int oxygenGranted;

    //Gives a configurable amount of oxygen to the frog when they eat it.
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {GameObject.Find("Oxygen_Meter").GetComponent<OxygenMeter>().AddOxygen(oxygenGranted);}
    }
}
