using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Camera_Follow : MonoBehaviour
{
    private Transform frogTform;
    private Vector3 frogVectors;

    //Grabs the position of the frog.
    void Start()
    {
        if (GameObject.FindWithTag("Player") == true)
        {frogTform = GameObject.Find("Frog").GetComponent<Transform>();}
    }

    //Moves the camera towards the frog, utilizing the position we just grabbed.
    //"Distance / 10" enables smooth movement - as the distance to the frog gets smaller each frame, the camera slows down.
    //Puts the result in a Vector3 first so that we can correct the Z value before sending it off to the camera's transform
    void Update()
    {
        if (GameObject.FindWithTag("Player") == true)
        {
            frogVectors = Vector3.MoveTowards(transform.position, frogTform.position,
            Mathf.Abs(Vector2.Distance(transform.position, frogTform.position)) / 6);

            frogVectors.z = -10.0f;
            transform.position = frogVectors;
        }
    }
}