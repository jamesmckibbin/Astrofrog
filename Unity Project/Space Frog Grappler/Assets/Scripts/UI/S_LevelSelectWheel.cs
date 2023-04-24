using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static System.Net.Mime.MediaTypeNames;
using Application = UnityEngine.Application;

public class S_LevelSelectWheel : MonoBehaviour
{
    public S_SceneSwitcher SceneSwitcher;
    public SceneInfo SceneIndexes;

    [SerializeField] private float turntableMod = 875000;
    [SerializeField] private float keyboardMod = 250;
    Gamepad gamepad = Gamepad.current;

    void Update()
    {
        if (gamepad != null)
            gamepad.SetMotorSpeeds(0, Mathf.Sin(Time.time * 4.5f) + 0.2f); //Makes tongue button pulse

        if (Input.GetButtonDown("Tongue"))
        {
            // Return to Main Menu
            if (transform.localRotation.eulerAngles.z > 270 && transform.localRotation.eulerAngles.z < 360)
            {
                GameObject.Find("AudioManager").GetComponent<S_AudioManager>().ClickSFX();
                StartCoroutine(SceneSwitcher.LoadScene(SceneIndexes.TitleScreen));
            }
            // Level 3
            else if (transform.localRotation.eulerAngles.z > 180 && transform.localRotation.eulerAngles.z < 270)
            {
                GameObject.Find("AudioManager").GetComponent<S_AudioManager>().ClickSFX();
                StartCoroutine(SceneSwitcher.LoadScene(SceneIndexes.Level_3));
            }
            // Level 2
            else if (transform.localRotation.eulerAngles.z > 90 && transform.localRotation.eulerAngles.z < 180)
            {
                GameObject.Find("AudioManager").GetComponent<S_AudioManager>().ClickSFX();
                StartCoroutine(SceneSwitcher.LoadScene(SceneIndexes.Level_2));
            }
            // Level 1
            else if (transform.localRotation.eulerAngles.z > 0 && transform.localRotation.eulerAngles.z < 90)
            {
                GameObject.Find("AudioManager").GetComponent<S_AudioManager>().ClickSFX();
                StartCoroutine(SceneSwitcher.LoadScene(SceneIndexes.Level_1));
            }
        }
    }

    private void FixedUpdate()
    {
        if (!(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
        {
            transform.eulerAngles += new Vector3(0, 0, (Input.GetAxisRaw("Vertical") * -turntableMod * Time.fixedDeltaTime));
        }
        else
        {
            transform.eulerAngles += new Vector3(0, 0, (Input.GetAxisRaw("Vertical") * -keyboardMod * Time.fixedDeltaTime));
        }
    }
}
