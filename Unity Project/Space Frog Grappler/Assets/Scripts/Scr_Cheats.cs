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

    private void Start()
    {
        sceneSwitcher = FindObjectOfType<Scr_Scene_Switcher>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {sceneSwitcher.LoadScene(sceneIndexes.TitleScreen);}

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {OxygenMeter.SetMaxOxygen(10);}

        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {OxygenMeter.SetMaxOxygen(9999);}
        
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {OxygenMeter.AddOxygen(5);}

        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {OxygenMeter.RemoveOxygen(5);}
    }
}
