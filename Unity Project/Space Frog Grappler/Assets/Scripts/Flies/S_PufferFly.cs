using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class S_PufferFly : MonoBehaviour
{
    private GameObject frog;

    [SerializeField] private SpriteRenderer flyBody;

    //Assigning our frog to the script.
    void Start()
    {
        frog = GameObject.Find("Frog");
    }

    //Checks if the frog's around, and if the fly hasn't been grabbed yet.
    //Making sure the fly isn't grabbed first is important to make sure puffed-up flies will hurt if grabbed 
    void Update()
    {
        if (GetComponent<S_EdibleBase>().Grabbed == false && GameObject.Find("Frog") != null)
        {
            DistanceCheck();
        }
    }

    //Checks the distance between the fly and the frog. If it's within a set distance the fly will become safe to eat.
    void DistanceCheck()
    {
        if (Vector2.Distance(transform.position, frog.transform.position) >= 7.0f)
        {
            gameObject.tag = "FlyEdible";
            flyBody.color = Color.white;
        }
        
        else
        {
            gameObject.tag = "FlyPoisonous";
            flyBody.color = Color.green;
        }
    }
}
