using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scr_Fly_Counter : MonoBehaviour
{
    public int fliesEaten, flyTotal;

    public TMP_Text flyText;

    void Start()
    {
        //Locates every fly in the level, assigns it to the fly total.
        flyTotal = GameObject.FindGameObjectsWithTag("FlyEdible").Length
        + GameObject.FindGameObjectsWithTag("FlyPoisonous").Length
        + GameObject.FindGameObjectsWithTag("FlySpiky").Length;

        fliesEaten = 0;

        //Concatenates the numbers into the text that will be shown on the UI.
        flyText.text = fliesEaten.ToString() + " / " + flyTotal.ToString();
    }

    public void CounterUpdate()
    {
        fliesEaten++;

        //Concatenates the numbers again.
        flyText.text = fliesEaten.ToString() + " / " + flyTotal.ToString();
    }
}