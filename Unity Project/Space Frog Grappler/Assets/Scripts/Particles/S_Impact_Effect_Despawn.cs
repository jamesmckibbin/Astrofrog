using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Impact_Effect_Despawn : MonoBehaviour
{
    //Orients the particles so they fly off in the opposite direction of that which the frog was coming from. Impulse shock?
    void Start()
    {
        transform.LookAt(GameObject.Find("Frog").transform, Vector3.forward);

        GetComponent<ParticleSystem>().Play(true);

        StartCoroutine(DestroyDelay());
    }

    //Destroys the particle effect after it finishes.
    private IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(1.0f);

        Destroy(this.gameObject);
    }
}