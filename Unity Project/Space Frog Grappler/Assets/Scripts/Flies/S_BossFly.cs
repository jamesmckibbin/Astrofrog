using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BossFly : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            GameObject.Find("ButtonManager").GetComponent<S_ButtonManager>().GoToEndScreen();
        }
    }
}
