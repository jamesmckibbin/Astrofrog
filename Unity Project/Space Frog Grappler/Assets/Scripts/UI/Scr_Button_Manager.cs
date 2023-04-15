using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Button_Manager : MonoBehaviour
{ 
    public SceneInfo sceneIndexes;
    private Scr_Scene_Switcher sceneSwitcher;

    private void Start()
    {
        sceneSwitcher = FindObjectOfType<Scr_Scene_Switcher>();
    }

    public void GoToTitleScreen()
    {
        StartCoroutine(sceneSwitcher.LoadScene(sceneIndexes.TitleScreen));
    }

    public void GoToLevels()
    {
        StartCoroutine(sceneSwitcher.LoadScene(sceneIndexes.LevelSelect));
    }

    public void GoToCredits()
    {
        StartCoroutine(sceneSwitcher.LoadScene(sceneIndexes.Credits));
    }

    public void GoToLevel1()
    {
        StartCoroutine(sceneSwitcher.LoadScene(sceneIndexes.Level_1));
    }

    public void ExitGame()
    {
        Application.Quit(); 
    }
}
