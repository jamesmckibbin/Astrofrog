using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Button_Manager : MonoBehaviour
{ 
    public SceneInfo sceneIndexes;
    private Scr_Scene_Switcher sceneSwitcher;

    private void Start()
    {sceneSwitcher = FindObjectOfType<Scr_Scene_Switcher>();}

    public void GoToTitleScreen()
    {StartCoroutine(sceneSwitcher.LoadScene(sceneIndexes.TitleScreen));}

    public void GoToCredits()
    {StartCoroutine(sceneSwitcher.LoadScene(sceneIndexes.Credits));}

    public void GoToSelectLevel()
    {StartCoroutine(sceneSwitcher.LoadScene(sceneIndexes.SelectLevel));}

    public void GoToGameOver()
    {StartCoroutine(sceneSwitcher.LoadScene(sceneIndexes.GameOver));}

    public void GoToEndScreen()
    {StartCoroutine(sceneSwitcher.LoadScene(sceneIndexes.EndScreen));}

    public void GoToLevel1()
    {StartCoroutine(sceneSwitcher.LoadScene(sceneIndexes.Level_1));}

    public void GoToLevel2()
    {StartCoroutine(sceneSwitcher.LoadScene(sceneIndexes.Level_2));}

    public void GoToLevel3()
    {StartCoroutine(sceneSwitcher.LoadScene(sceneIndexes.Level_3));}

    public void ExitGame()
    {Application.Quit();}
}