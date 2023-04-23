using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_PauseOptions : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseToggle();
        }
    }

    //Toggles the pause menu's state between being active and inactive. Also freezes/unfreezes time accordingly.
    public void PauseToggle()
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

    //These two functions are here because SceneSwitcher doesn't work for prefabs.
    public void PauseExitLevel()
    {
        SceneManager.LoadScene("Sce_Select_Level");
    }

    public void PauseQuitGame()
    {
        Application.Quit();
    }
}