using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Frog_Hurt : MonoBehaviour
{
    //If a poisonous fly is eaten, Scr_Fly_Base calls this.
    //Spiky and poisonous objects (i.e. spike shields, poison bullets) do not use this yet, but will in the future.
    public void Pain()
    {
        //Insert bad things here
        print("oof ouchies that hurts!");
        FindObjectOfType<Scr_Oxygen_Meter>().RemoveOxygen(25);
    }
}