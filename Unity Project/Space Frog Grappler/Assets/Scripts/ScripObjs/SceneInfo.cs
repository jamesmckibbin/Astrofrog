using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SceneInfo : ScriptableObject
{
    // Please update these to the scene names when creating and implementing new scenes
    // Write them in descending order from first scene to last scene

    public int TitleScreen;
    public int Credits;
    public int LevelSelect;
    public int Level_1;
    public int Level_2;
    public int Level_3;
    public int GameOver;
    public int EndScreen;
}
