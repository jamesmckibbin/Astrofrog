using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Cheats : MonoBehaviour
{
    // Cheat controls for demo
    // To use, just put the cheats prefab into the scene
    // Just make sure to attatch all public variables
    // Feel free to add your own variables and cheats!

    public Scr_Oxygen_Meter oxygenMeter;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            oxygenMeter.SetMaxOxygen(10);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            oxygenMeter.SetMaxOxygen(9999);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            oxygenMeter.AddOxygen(5);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            oxygenMeter.RemoveOxygen(5);
        }
    }
}
