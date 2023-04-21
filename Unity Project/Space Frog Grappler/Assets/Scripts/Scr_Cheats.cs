using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_Cheats : MonoBehaviour
{
    // Cheat controls for demo
    // To use, just put the cheats prefab into the scene
    // Just make sure to attach all public variables
    // Feel free to add your own variables and cheats!

    public Scr_Oxygen_Meter OxygenMeter;
    public SceneInfo sceneIndexes;
    private Scr_Scene_Switcher sceneSwitcher;
    private Scr_Jetpack_Effect jetpack;

    private void Start()
    {
        sceneSwitcher = FindObjectOfType<Scr_Scene_Switcher>();
        jetpack = FindObjectOfType<Scr_Jetpack_Effect>();
    }

    void Update()
    {
        //Go back to the title screen.
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {sceneSwitcher.LoadScene(sceneIndexes.TitleScreen);}

        //Good for going to the game over screen quickly.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {OxygenMeter.SetMaxOxygen(10);}

        //Nearly unlimited oxygen.
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {OxygenMeter.SetMaxOxygen(9999);}
        
        //Add or remove oxygen.
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {OxygenMeter.AddOxygen(5);}

        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {OxygenMeter.RemoveOxygen(5);}

        //Enables the jetpack. Press again to disable.
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {jetpack.PackinTime = true;}
    }
}