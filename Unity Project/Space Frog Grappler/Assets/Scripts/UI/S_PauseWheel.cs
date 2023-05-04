using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static System.Net.Mime.MediaTypeNames;
using Application = UnityEngine.Application;

public class S_PauseWheel : MonoBehaviour
{
    public S_SceneSwitcher SceneSwitcher;
    public SceneInfo SceneIndexes;
    public S_PauseOptions pauseOptions;

    [SerializeField] private float turntableMod = 875000;
    [SerializeField] private float keyboardMod = 250;
    Gamepad gamepad = Gamepad.current;

    void Update()
    {
        if (gamepad != null)
            gamepad.SetMotorSpeeds(0, Mathf.Sin(Time.unscaledTime * 4.5f) + 0.2f); //Makes tongue button pulse

        if (Input.GetButtonDown("Tongue"))
        {
            // Quit Game
            if (transform.localEulerAngles.z > 180 && transform.localEulerAngles.z < 300)
            {
                print("Quit");
                GameObject.Find("AudioManager").GetComponent<S_AudioManager>().ClickSFX();
                Application.Quit();
            }
            // Level Select
            else if (transform.localEulerAngles.z > 60 && transform.localEulerAngles.z < 180)
            {
                print("Exit");
                GameObject.Find("AudioManager").GetComponent<S_AudioManager>().ClickSFX();
                StartCoroutine(SceneSwitcher.LoadScene(SceneIndexes.SelectLevel));
            }
            // Resume Level
            else if ((transform.localEulerAngles.z > 0 && transform.localEulerAngles.z < 60) ||
                     (transform.localEulerAngles.z > 300 && transform.localEulerAngles.z < 360))
            {
                print("Resume");
                pauseOptions.PauseToggle();
            }
        }
    }

    private void FixedUpdate()
    {
        if (!(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
        {
            transform.eulerAngles += new Vector3(0, 0, (Input.GetAxisRaw("Vertical") * -turntableMod * Time.fixedUnscaledDeltaTime));
        }
        else
        {
            transform.eulerAngles += new Vector3(0, 0, (Input.GetAxisRaw("Vertical") * -keyboardMod * Time.fixedUnscaledDeltaTime));
        }
    }
}
