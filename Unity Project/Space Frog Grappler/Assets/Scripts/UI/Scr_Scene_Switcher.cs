using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_Scene_Switcher : MonoBehaviour 
{
    [SerializeField] private Animator transition;
    private static Scr_Scene_Switcher instance;
    void Start()
    {
        if (instance == null)
        {instance = this;}

        else
        {Object.Destroy(this.gameObject);}

        transition.SetTrigger("Start");
    }

    public IEnumerator LoadScene(int levelIndex)
    {
        transition.SetTrigger("End");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(levelIndex);
    }
}
