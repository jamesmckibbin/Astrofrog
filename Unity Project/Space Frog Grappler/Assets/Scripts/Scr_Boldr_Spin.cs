using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Boldr_Spin : MonoBehaviour
{
    [SerializeField] float SpinSpeed;

    //A spinning wall... How curious.
    void FixedUpdate()
    {transform.Rotate(0.0f, 0.0f, SpinSpeed);}
}