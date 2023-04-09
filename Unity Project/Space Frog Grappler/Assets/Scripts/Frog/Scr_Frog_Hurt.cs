using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Frog_Hurt : MonoBehaviour
{
    //If the frog gets hurt (i.e. spikes, ingesting poison) this is called externally.
    public void Pain()
    {
        print("oof ouchies that hurts!");
        FindObjectOfType<Scr_Oxygen_Meter>().RemoveOxygen(25);
    }
}