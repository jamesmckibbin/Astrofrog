using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A spinning wall... How curious.

public class S_BoldrSpin : MonoBehaviour
{
    [SerializeField] private float SpinSpeed;
    void FixedUpdate()
    {
        transform.Rotate(0.0f, 0.0f, SpinSpeed);
    }
}