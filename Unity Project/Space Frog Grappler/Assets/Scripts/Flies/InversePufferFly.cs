using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InversePufferFly : MonoBehaviour
{
    [SerializeField] private SpriteRenderer flyRender;
    [SerializeField] private Color poisonGreen;
    private GameObject frog;

    //Assigning our frog to the script.
    void Start()
    {
        frog = GameObject.Find("Frog");
    }

    //Checks if the frog's around, and if the fly hasn't been grabbed yet.
    //Making sure the fly isn't grabbed first is important to make sure puffed-up flies will hurt if grabbed 
    void Update()
    {
        if (GetComponent<EdibleBase>().Grabbed == false && GameObject.Find("Frog") != null)
        {
            DistanceCheck();
        }
    }

    //Checks the distance between the fly and the frog. If it's within a set distance the fly will become safe to eat.
    void DistanceCheck()
    {
        if (Vector2.Distance(transform.position, frog.transform.position) <= 5.0f)
        {
            gameObject.tag = "FlyEdible";
            flyRender.material.color = Color.black;
            transform.localScale = new Vector3 (0.7f, 0.7f, 0.5f);
        }
        
        else
        {
            gameObject.tag = "FlyPoisonous";
            flyRender.material.color = poisonGreen;
            transform.localScale = new Vector3 (1.0f, 1.0f, 0.5f);
        }
    }
}
