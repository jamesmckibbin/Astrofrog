using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A broad class for all things edible by the frog. This includes flies, projectiles and pickups.

public class EdibleBase : MonoBehaviour
{
    public bool Grabbed = false;
    private Transform tongue;

    void OnTriggerEnter2D(Collider2D col)
    {
        //Attaches the object to the tongue if the other collider in question belongs to the tongue
        if (col.gameObject.CompareTag("Tongue"))
        {
            Grabbed = true;
            tongue = col.transform;
        }
        
        //Makes it so the object will be eaten once it collides with the frog's body
        if (col.tag == "Player")
        {
            //Plays chomping sound effect
            GameObject.Find("AudioManager").GetComponent<AudioManager>().ChompSFX();
            
            Destroy(this.gameObject);

            if (CompareTag("Poisonous") || CompareTag("FlyPoisonous"))
            {GameObject.Find("Frog").GetComponent<PlayerHurt>().Pain();}
        }
    }

    //The object follows the movements of the tip of the tongue, so it will be reeled in when the tongue retracts.
    void Update()
    {
        if (Grabbed)
        {
            transform.position = tongue.position;
        }
    }
}