using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_SceneSwitcher : MonoBehaviour 
{
    [SerializeField] private Animator transition;
    private static S_SceneSwitcher instance;
    void Start()
    {
        transition.SetTrigger("Start");
    }

    public IEnumerator LoadScene(int levelIndex)
    {
        transition.SetTrigger("End");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(levelIndex);
    }
}
