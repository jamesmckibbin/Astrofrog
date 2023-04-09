using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Fly_Base : MonoBehaviour
{
    //The old Fly_Base was converted into the broader Edible_Base; this just contains the call to Fly_Counter.
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {GameObject.Find("Text_Fly_Counter").GetComponent<Scr_Fly_Counter>().CounterUpdate();}
    }
}