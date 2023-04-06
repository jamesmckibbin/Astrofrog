using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Fly_Base : MonoBehaviour
{
    public bool grabbed = false;
    private Transform tongue;

    //In order to not 
    void OnTriggerEnter2D(Collider2D col)
    {
        //Attaches the fly to the tongue if the other collider in question belongs to the tongue
        if (col.tag == "Tongue")
        grabbed = true;
        tongue = col.transform;
        
        //Makes it so the fly will be eaten once it collides with the frog's body
        if (col.tag == "Player")
        {
            Destroy(this.gameObject);

            if (tag == "Poisonous")
            {GameObject.Find("Frog").GetComponent<Scr_Frog_Hurt>().Pain();}

            GameObject.Find("Fly_Counter").GetComponent<Scr_Fly_Counter>().CounterUpdate();
        }
    }

    //The fly follows the movements of the tip of the tongue, so it will be reeled in when the tongue retracts.
    void Update()
    {
        if (grabbed)
        {transform.position = tongue.position;}
    }
}