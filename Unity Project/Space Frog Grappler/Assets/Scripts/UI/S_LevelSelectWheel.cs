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

    public int previewedLevel;

    void Update()
    {
        if (gamepad != null)
            gamepad.SetMotorSpeeds(0, Mathf.Sin(Time.time * 4.5f) + 0.2f); //Makes tongue button pulse

        // Return to Main Menu
        if (transform.localRotation.eulerAngles.z > 270 && transform.localRotation.eulerAngles.z < 360)
        {previewedLevel = 4;}

        // Level 3
        else if (transform.localRotation.eulerAngles.z > 180 && transform.localRotation.eulerAngles.z < 270)
        {previewedLevel = 3;}

        // Level 2
        else if (transform.localRotation.eulerAngles.z > 90 && transform.localRotation.eulerAngles.z < 180)
        {previewedLevel = 2;}

        // Level 1
        else if (transform.localRotation.eulerAngles.z > 0 && transform.localRotation.eulerAngles.z < 90)
        {previewedLevel = 1;}

        if (Input.GetButtonDown("Tongue"))
        {
            GameObject.Find("AudioManager").GetComponent<S_AudioManager>().ClickSFX();

            switch (previewedLevel)
            {
                case 1:
                    StartCoroutine(SceneSwitcher.LoadScene(SceneIndexes.Level_1));
                    break;

                case 2:
                    StartCoroutine(SceneSwitcher.LoadScene(SceneIndexes.Level_2));
                    break;

                case 3:
                    StartCoroutine(SceneSwitcher.LoadScene(SceneIndexes.Level_3));
                    break;

                case 4:
                    StartCoroutine(SceneSwitcher.LoadScene(SceneIndexes.TitleScreen));
                    break;

                default:
                    break;
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
