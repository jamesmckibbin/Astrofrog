using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Inverse_Puffer_Fly : MonoBehaviour
{
    private GameObject frog;

    [SerializeField] SpriteRenderer flyRender;
    [SerializeField] Color poisonGreen;

    //Assigning our the frog we're playing as to the script.
    void Start()
    {frog = GameObject.Find("Frog");}

    //Checks if the frog's around, and if the fly hasn't been grabbed yet.
    //Making sure the fly isn't grabbed first is important to make sure puffed-up flies will hurt if grabbed 
    void Update()
    {
        if (GetComponent<Scr_Fly_Base>().grabbed == false && GameObject.Find("Frog") != null)
        {DistanceCheck();}
    }

    //Checks the distance between the fly and the frog. If it's within a set distance the fly will become safe to eat.
    void DistanceCheck()
    {
        if (Vector2.Distance(transform.position, frog.transform.position) <= 5.0f)
        {
            gameObject.tag = "Fly";
            flyRender.material.color = Color.black;
            transform.localScale = new Vector3 (0.7f, 0.7f, 0.5f);
        }
        else
        {
            gameObject.tag = "Poisonous";
            flyRender.material.color = poisonGreen;
            transform.localScale = new Vector3 (1.0f, 1.0f, 0.5f);
        }
    }
}