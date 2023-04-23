using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour 
{
    [SerializeField] private Animator transition;
    private static SceneSwitcher instance;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Object.Destroy(this.gameObject);
        }

        transition.SetTrigger("Start");
    }

    public IEnumerator LoadScene(int levelIndex)
    {
        transition.SetTrigger("End");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(levelIndex);
    }
}
