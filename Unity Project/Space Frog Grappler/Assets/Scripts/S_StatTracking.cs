using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class S_StatTracking : MonoBehaviour
{
    private string startScene;

    private int flyTotal, fliesEaten;
    private float startTime, endTime;

    private int maxFliesToCheck, bestFliesToCheck;
    private float bestTimeToCheck;

    private string lineFlies;
    private string lineTime;

    private TextMeshProUGUI flyText;

    public ScoreInfo scoreIndexes;

    //This object starts on a level scene. It first tracks what level it started on and how many flies are in it.
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        startTime = Time.time;

        startScene = SceneManager.GetActiveScene().name;

        switch (SceneManager.GetActiveScene().name)
        {
            case "Level1":
                maxFliesToCheck = scoreIndexes.MaxFlies1;
                bestFliesToCheck = scoreIndexes.BestFlies1;
                bestTimeToCheck = scoreIndexes.BestTime1;
                break;

            case "Level2":
                maxFliesToCheck = scoreIndexes.MaxFlies2;
                bestFliesToCheck = scoreIndexes.BestFlies2;
                bestTimeToCheck = scoreIndexes.BestTime2;
                break;

            case "Level3":
                maxFliesToCheck = scoreIndexes.MaxFlies3;
                bestFliesToCheck = scoreIndexes.BestFlies3;
                bestTimeToCheck = scoreIndexes.BestTime3;
                break;

            default:
                print("hey, this level ain't named right! i quit!");
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
        if (SceneManager.GetActiveScene().name == startScene)
        {fliesEaten = GameObject.Find("Text_Fly_Counter").GetComponent<S_FlyCounter>().fliesEaten;}

        else if (SceneManager.GetActiveScene().name == "GameOver" || SceneManager.GetActiveScene().name == "CompletedLevel")
        {TallyScores();}

        else
        {Destroy(this.gameObject);}
    }

    //Gives the amount of flies eaten to the end screen.
    //Also gives the clear time if applicable!
    void TallyScores()
    {
        flyText = GameObject.Find("Text_Final_Score").GetComponent<TextMeshProUGUI>();

        lineFlies = "You ate " + fliesEaten + " / " + flyTotal + " flies!";

        if (SceneManager.GetActiveScene().name == "CompletedLevel")
        {
            endTime = Time.time - startTime;

            lineTime = "Your time: " + endTime.ToString("F2") + " seconds!";

            flyText.text = lineFlies + System.Environment.NewLine + lineTime;
        }
        
        else
        {flyText.text = lineFlies;}

        RecordScores();
    }

    //Updates ScoreInfo if necessary, then destroys itself.
    void RecordScores()
    {
        switch (startScene)
        {
            case "Level1":
                scoreIndexes.MaxFlies1 = flyTotal;

                if (fliesEaten > bestFliesToCheck)
                {scoreIndexes.BestFlies1 = fliesEaten;}

                if (SceneManager.GetActiveScene().name == "CompletedLevel" && endTime < bestTimeToCheck)
                {scoreIndexes.BestTime1 = endTime;}
                break;

            case "Level2":
                scoreIndexes.MaxFlies2 = flyTotal;

                if (fliesEaten > bestFliesToCheck)
                {scoreIndexes.BestFlies2 = fliesEaten;}

                if (SceneManager.GetActiveScene().name == "CompletedLevel" && endTime < bestTimeToCheck)
                {scoreIndexes.BestTime2 = endTime;}
                break;

            case "Level3":
                scoreIndexes.MaxFlies3 = flyTotal;

                if (fliesEaten > bestFliesToCheck)
                {scoreIndexes.BestFlies3 = fliesEaten;}

                if (SceneManager.GetActiveScene().name == "CompletedLevel" && endTime < bestTimeToCheck)
                {scoreIndexes.BestTime3 = endTime;}
                break;

            default:
                break;
        }

        Destroy(this.gameObject);
    }
}