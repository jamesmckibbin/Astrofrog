using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerHurt : MonoBehaviour
{
    private Animator animator;
    //If the frog gets hurt (i.e. spikes, ingesting poison) this is called externally.
    public void Pain()
    {
        animator = GetComponentInChildren<Animator>();
        FindObjectOfType<S_OxygenMeter>().RemoveOxygen(25);
        animator.SetTrigger("Hurt");
    }
}