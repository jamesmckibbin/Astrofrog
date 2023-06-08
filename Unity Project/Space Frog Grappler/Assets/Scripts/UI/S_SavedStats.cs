using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class S_SavedStats : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI statsText;

    [SerializeField] ScoreInfo scoreIndexes;
    [SerializeField] S_LevelSelectWheel wheel;

    private int maxFliesToCheck, bestFliesToCheck;
    private float bestTimeToCheck;

    private string lineFlies;
    private string lineTime;

    // Update is called once per frame
    void Update()
    {
        //Decides what stats it has to check based on the wheel's previewed level.
        switch (wheel.previewedLevel)
        {
            case 1:
                maxFliesToCheck = scoreIndexes.MaxFlies1;
                bestFliesToCheck = scoreIndexes.BestFlies1;
                bestTimeToCheck = scoreIndexes.BestTime1;
                break;
                
            case 2:
                maxFliesToCheck = scoreIndexes.MaxFlies2;
                bestFliesToCheck = scoreIndexes.BestFlies2;
                bestTimeToCheck = scoreIndexes.BestTime2;
                break;

            case 3:
                maxFliesToCheck = scoreIndexes.MaxFlies3;
                bestFliesToCheck = scoreIndexes.BestFlies3;
                bestTimeToCheck = scoreIndexes.BestTime3;
                break;

            default:
                break;
        }

        //Concatenates together text depending on what stats the script was told to check.
        if (wheel.previewedLevel > 0 && wheel.previewedLevel < 4)
        {
            if (maxFliesToCheck == 0)
            {
                lineFlies = "Flies eaten: 0 / ?";
                lineTime = "Best time: Not set!";
            }

            else if (bestTimeToCheck == 999999.0f)
            {
                lineFlies = "Flies eaten: " + bestFliesToCheck + " / " + maxFliesToCheck;
                lineTime = "Best time: Not set!";
            }

            else
            {
                lineFlies = "Flies eaten: " + bestFliesToCheck + " / " + maxFliesToCheck;
                lineTime = "Best time: " + bestTimeToCheck.ToString("F2") + " s";
            }

            statsText.text = lineFlies + System.Environment.NewLine + lineTime;
        }
        
        //Displays no text if a level isn't being previewed.
        else
        {statsText.text = "";}
    }
}
