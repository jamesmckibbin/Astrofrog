using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Jetpack_Effect : MonoBehaviour
{
    public IEnumerator coroutine;
    public bool PackinTime = false;

    [SerializeField] Rigidbody2D frogRb;
    private float propulsion;

    public void JetpackStart(float duration)
    {StartCoroutine(JetpackDuration(duration));}

    //Propels the frog forward for as long as the jetpack is active.
    void FixedUpdate()
    {
        if (PackinTime)
        {
            frogRb.velocity = transform.up * propulsion;
            
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {propulsion = Mathf.Clamp(propulsion - 0.1f, 0.0f, 8);}
            else
            {propulsion = Mathf.Clamp(propulsion + 0.09f, 0.0f, 8);}
        }
    }

    //Stops the jetpack after its duration ends.
    private IEnumerator JetpackDuration(float duration)
    {
        print("called!");
        
        yield return new WaitForSeconds(duration);

        PackinTime = false;
        print("ended!");
    }
}