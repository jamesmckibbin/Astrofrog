using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_JetpackEffect : MonoBehaviour
{
    public IEnumerator coroutine;
    public bool PackinTime = false;

    [SerializeField] Rigidbody2D frogRb;
    public ParticleSystem nitroJet;

    public void JetpackStart(float duration2)
    { StartCoroutine(JetpackDuration(duration2)); }

    //Propulsion for when the jetpack is active.
    void FixedUpdate()
    {
        if (PackinTime)
        {
            GameObject.Find("AudioManager").GetComponent<S_AudioManager>().JetSFXOn();
            //Propels the frog forward if their speed in the direction they're facing isn't at a set amount.
            float velocityInDirection = Vector3.Dot(frogRb.velocity, transform.up);

            if (velocityInDirection < 7.0f)
            {
                frogRb.AddForce(transform.up * 10.0f);
                nitroJet.Play();
            }

            else
            { nitroJet.Stop(); }
        }
    }

    //Stops the jetpack after its duration ends.
    private IEnumerator JetpackDuration(float duration3)
    {
        yield return new WaitForSeconds(duration3);

        PackinTime = false;
        nitroJet.Stop();
        GameObject.Find("AudioManager").GetComponent<S_AudioManager>().JetSFXOff();
    }
}