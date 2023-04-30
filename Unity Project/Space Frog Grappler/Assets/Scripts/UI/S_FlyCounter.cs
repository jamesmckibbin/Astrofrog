using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class S_FlyCounter : MonoBehaviour
{
    public int fliesEaten, flyTotal;

    public TextMeshProUGUI flyText;

    void Start()
    {
        //Locates every fly in the level, assigns it to the fly total.
        flyTotal = GameObject.FindGameObjectsWithTag("FlyEdible").Length
        + GameObject.FindGameObjectsWithTag("FlyPoisonous").Length
        + GameObject.FindGameObjectsWithTag("FlySpiky").Length;

        fliesEaten = 0;

        //Concatenates the numbers into the text that will be shown on the UI.
        flyText.text = "Flies Eaten: " + fliesEaten.ToString() + "/" + flyTotal.ToString();
    }

    public void CounterUpdate()
    {
        fliesEaten++;

        //Concatenates the numbers again.
        flyText.text = "Flies Eaten: " + fliesEaten.ToString() + "/" + flyTotal.ToString();
    }
}