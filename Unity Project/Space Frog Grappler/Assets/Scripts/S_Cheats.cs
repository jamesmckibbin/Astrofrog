using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_Cheats : MonoBehaviour
{
    // Cheat controls for demo
    // To use, just put the cheats prefab into the scene
    // Just make sure to attach all public variables
    // Feel free to add your own variables and cheats!

    public S_OxygenMeter OxygenMeter;
    public SceneInfo sceneIndexes;
    private S_SceneSwitcher sceneSwitcher;
    private S_JetpackEffect jetpack;

    private void Start()
    {
        sceneSwitcher = FindObjectOfType<S_SceneSwitcher>();
        jetpack = FindObjectOfType<S_JetpackEffect>();
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