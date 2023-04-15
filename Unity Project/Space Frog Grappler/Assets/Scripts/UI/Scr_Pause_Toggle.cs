using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Pause_Toggle : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    //Toggles the pause menu's state between being active and inactive. Also freezes/unfreezes time accordingly.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {Toggle();}
    }

    public void Toggle()
    {
        if (pauseMenu.activeSelf == false)
        {
            Time.timeScale = 0.0f;
            pauseMenu.SetActive(true);
        }

        else
        {
            Time.timeScale = 1.0f;
            pauseMenu.SetActive(false);
        }
    }
}