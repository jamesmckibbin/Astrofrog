using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Scr_Stat_Tracking : MonoBehaviour
{
    private int whatLevel, flyTotal, fliesEaten;

    private TextMeshProUGUI flyText;

    public ScoreInfo scoreIndexes;

    //This object starts on a level scene. It first tracks what level it started on and how many flies are in it.
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        switch (SceneManager.GetActiveScene().name)
        {
            case "Sce_Level_1":
                whatLevel = 1;
                break;

            case "Sce_Level_2":
                whatLevel = 2;
                break;

            case "Sce_Level_3":
                whatLevel = 3;
                break;
        }

        flyTotal = GameObject.Find("Text_Fly_Counter").GetComponent<Scr_Fly_Counter>().flyTotal;
    }

    //Regularly grabs how many flies have been eaten. 
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Contains("Sce_Level_1"))
        {fliesEaten = GameObject.Find("Text_Fly_Counter").GetComponent<Scr_Fly_Counter>().fliesEaten;}
        
        if (SceneManager.GetActiveScene().name == "Sce_Game_Over" || SceneManager.GetActiveScene().name == "Sce_Complete_Level")
        {TallyScores();}

        else if (SceneManager.GetActiveScene().name == "Sce_Select_Level")
        {Destroy(this.gameObject);}
    }

    //Gives its numbers to the level complete / game over screen.
    //Then it updates ScoreInfo if necessary and destroys itself.
    void TallyScores()
    {
        flyText = GameObject.Find("Text_Final_Score").GetComponent<TextMeshProUGUI>();
            
        flyText.text = fliesEaten.ToString() + " / " + flyTotal.ToString() + " flies!";

        switch (whatLevel)
        {
            case 1:
                scoreIndexes.MaxLevel1 = flyTotal;

                if (fliesEaten > scoreIndexes.BestLevel1)
                {scoreIndexes.BestLevel1 = fliesEaten;}
                break;

            case 2:
                scoreIndexes.MaxLevel2 = flyTotal;

                if (fliesEaten > scoreIndexes.BestLevel2)
                {scoreIndexes.BestLevel2 = fliesEaten;}
                break;

            case 3:
                scoreIndexes.MaxLevel3 = flyTotal;

                if (fliesEaten > scoreIndexes.BestLevel3)
                {scoreIndexes.BestLevel3 = fliesEaten;}
                break;

            default:
                break;
        }

        Destroy(this.gameObject);
    }
}