using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class S_StatTracking : MonoBehaviour
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
            case "Level1":
                whatLevel = 1;
                break;

            case "Level2":
                whatLevel = 2;
                break;

            case "Level3":
                whatLevel = 3;
                break;

            default:
                print("hey, this level ain't named right!");
                Destroy(this.gameObject);
                break;
        }

        StartCoroutine(TotalFind());
    }

    //The tracker waits for a frame before grabbing information from S_FlyCounter.
    //This prevents a bug where the tracker searched the fly counter prematurely, so it would only find a zero.
    IEnumerator TotalFind()
    {
        yield return 0;

        flyTotal = GameObject.Find("Text_Fly_Counter").GetComponent<S_FlyCounter>().flyTotal;
        print(flyTotal);
    }

    //Regularly grabs how many flies have been eaten. 
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level1" ||
        SceneManager.GetActiveScene().name == "Level2" ||
        SceneManager.GetActiveScene().name == "Level3")
        {fliesEaten = GameObject.Find("Text_Fly_Counter").GetComponent<S_FlyCounter>().fliesEaten;}

        else if (SceneManager.GetActiveScene().name == "GameOver" ||
        SceneManager.GetActiveScene().name == "CompletedLevel")
        {TallyScores();}

        else
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
                scoreIndexes.MaxFlies1 = flyTotal;

                if (fliesEaten > scoreIndexes.BestFlies1)
                {scoreIndexes.BestFlies1 = fliesEaten;}
                break;

            case 2:
                scoreIndexes.MaxFlies2 = flyTotal;

                if (fliesEaten > scoreIndexes.BestFlies2)
                {scoreIndexes.BestFlies2 = fliesEaten;}
                break;

            case 3:
                scoreIndexes.MaxFlies3 = flyTotal;

                if (fliesEaten > scoreIndexes.BestFlies3)
                {scoreIndexes.BestFlies3 = fliesEaten;}
                break;

            default:
                break;
        }

        Destroy(this.gameObject);
    }
}