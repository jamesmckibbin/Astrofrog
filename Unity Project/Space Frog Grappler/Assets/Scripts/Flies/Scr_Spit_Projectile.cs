using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Spit_Projectile : MonoBehaviour
{
    private bool canSpit = true;

    [SerializeField] GameObject projectile;
    [SerializeField] float spitDirection;
    [SerializeField] float foreswing;
    [SerializeField] float backswing;

    //Tells the fly when to spit a projectile.
    void Update()
    {
        if (canSpit)
        {
            StartCoroutine(Spit());
            canSpit = false;
        }
    }

    //Spits a projectile. Its direction and timing can be tweaked in the editor. 
    IEnumerator Spit()
    {
        yield return new WaitForSeconds(foreswing);

        Instantiate(projectile, transform.position, new Quaternion (0.0f, 0.0f, spitDirection * Mathf.Deg2Rad, 1.0f));

        yield return new WaitForSeconds(backswing);
        canSpit = true;
    }
}