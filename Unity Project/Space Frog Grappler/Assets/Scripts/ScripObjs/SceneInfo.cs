using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SceneInfo : ScriptableObject
{
    // Please update these to the scene names when creating and implementing new scenes
    // Write them in descending order from first scene to last scene

    public int TitleScreen, Credits, SelectLevel, GameOver, EndScreen, Level_1, Level_2, Level_3;
}