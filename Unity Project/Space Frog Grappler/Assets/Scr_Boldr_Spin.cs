using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Boldr_Spin : MonoBehaviour
{
    public float SpinSpeed;

    //A spinning wall... How curious.
    void Update()
    {transform.Rotate(0.0f, 0.0f, SpinSpeed);}
}