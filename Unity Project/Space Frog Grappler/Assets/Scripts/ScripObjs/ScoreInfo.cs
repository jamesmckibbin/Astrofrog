using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Keeps track of the player's best scores.
[CreateAssetMenu]
public class ScoreInfo : ScriptableObject
{
    public int MaxFlies1, MaxFlies2, MaxFlies3, BestFlies1, BestFlies2, BestFlies3;
    public float BestTime1, BestTime2, BestTime3;
}