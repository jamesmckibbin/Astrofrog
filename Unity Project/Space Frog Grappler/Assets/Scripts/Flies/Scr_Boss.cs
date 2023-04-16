using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Boss : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {GameObject.Find("ButtonManager").GetComponent<Scr_Button_Manager>().GoToEndScreen();}
    }
}
