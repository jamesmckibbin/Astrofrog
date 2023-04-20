using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Jetpack_Effect : MonoBehaviour
{
    [SerializeField] Rigidbody2D frogRb;
    public bool packinTime = false;

    private float forceAmount;

    //Propels the frog forward for as long as the jetpack is active.
    void FixedUpdate()
    {
        if (packinTime)
        {
            print(frogRb.velocity.magnitude);
            forceAmount = Mathf.Clamp(((8.0f / frogRb.velocity.magnitude) - 1), 0.0f, 8.0f);
            print(forceAmount);
            frogRb.AddForce(transform.up * forceAmount, ForceMode2D.Force);
        }
    }

    //Stops the jetpack after its duration ends.
    public IEnumerator JetpackDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        print("jetpack deactivated!");
        packinTime = false;
    }
}