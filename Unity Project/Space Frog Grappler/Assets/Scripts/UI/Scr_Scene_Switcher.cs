using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_Scene_Switcher : MonoBehaviour 
{
    private static Scr_Scene_Switcher instance;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Object.Destroy(this.gameObject);
        }
    }

    public IEnumerator LoadScene(int levelIndex)
    {
        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene(levelIndex);
    }
}
