using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StatTracking : MonoBehaviour
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

        flyTotal = GameObject.Find("Text_Fly_Counter").GetComponent<FlyCounter>().flyTotal;
    }

    //Regularly grabs how many flies have been eaten. 
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Contains("Level1"))
        {
            fliesEaten = GameObject.Find("Text_Fly_Counter").GetComponent<FlyCounter>().fliesEaten;
        }

        if (SceneManager.GetActiveScene().name == "GameOver" ||
            SceneManager.GetActiveScene().name == "CompletedLevel")
        {
            TallyScores();
        }

        else if (SceneManager.GetActiveScene().name == "LevelSelect") {}
    }

    //Gives its numbers to the level complete / game over screen.
    //Then it updates ScoreInfo if necessary and destroys itself.
    void TallyScores()
    {
        print(fliesEaten.ToString() + " / " + flyTotal.ToString() + "flies!");

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
        }

        Destroy(this.gameObject);
    }
}