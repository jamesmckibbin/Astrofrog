using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static System.Net.Mime.MediaTypeNames;
using Application = UnityEngine.Application;

public class S_CreditsScreen : MonoBehaviour
{
    public S_SceneSwitcher SceneSwitcher;
    public SceneInfo SceneIndexes;
    Gamepad gamepad = Gamepad.current;

    void Update()
    {
        if (gamepad != null)
            gamepad.SetMotorSpeeds(0, Mathf.Sin(Time.time * 4.5f) + 0.2f); //Makes tongue button pulse

        if (Input.GetButtonDown("Tongue"))
        {
            GameObject.Find("AudioManager").GetComponent<S_AudioManager>().ClickSFX();
            StartCoroutine(SceneSwitcher.LoadScene(SceneIndexes.TitleScreen));
        }
    }
}
