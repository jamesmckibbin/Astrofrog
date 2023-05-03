using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static System.Net.Mime.MediaTypeNames;
using Application = UnityEngine.Application;
using TMPro;

public class S_FrogSelect : MonoBehaviour
{
    public S_SceneSwitcher SceneSwitcher;
    public SceneInfo SceneIndexes;

    public GameObject selectedTextA;
    public GameObject selectedTextBL;
    public GameObject selectedTextFan;
    public GameObject selectedTextD;

    [SerializeField] private float turntableMod = 875000;
    [SerializeField] private float keyboardMod = 250;
    Gamepad gamepad = Gamepad.current;

    public int previewedFrog;
    public int chosenFrog = 1;

    void Update()
    {
        if (gamepad != null)
            gamepad.SetMotorSpeeds(0, Mathf.Sin(Time.time * 4.5f) + 0.2f); //Makes tongue button pulse

        // Return to Main Menu
        if (transform.localRotation.eulerAngles.z > 288 && transform.localRotation.eulerAngles.z < 360)
        { 
            previewedFrog = 5;

            if (chosenFrog == 4)
            {
                selectedTextA.SetActive(false);
                selectedTextBL.SetActive(false);
                selectedTextD.SetActive(false);
                selectedTextFan.SetActive(true);
            }
            else
            {
                selectedTextA.SetActive(false);
                selectedTextBL.SetActive(false);
                selectedTextD.SetActive(false);
                selectedTextFan.SetActive(false);
            }
        }

        // Level 3
        else if (transform.localRotation.eulerAngles.z > 216 && transform.localRotation.eulerAngles.z < 288)
        { 
            previewedFrog = 4;

            if (chosenFrog == 3)
            {
                selectedTextA.SetActive(false);
                selectedTextBL.SetActive(false);
                selectedTextD.SetActive(true);
                selectedTextFan.SetActive(false);
            }
            else
            {
                selectedTextA.SetActive(false);
                selectedTextBL.SetActive(false);
                selectedTextD.SetActive(false);
                selectedTextFan.SetActive(false);
            }
        }

        // Level 2
        else if (transform.localRotation.eulerAngles.z > 144 && transform.localRotation.eulerAngles.z < 216)
        { 
            previewedFrog = 3;

            if (chosenFrog == 2)
            {
                selectedTextA.SetActive(false);
                selectedTextBL.SetActive(true);
                selectedTextD.SetActive(false);
                selectedTextFan.SetActive(false);
            }
            else
            {
                selectedTextA.SetActive(false);
                selectedTextBL.SetActive(false);
                selectedTextD.SetActive(false);
                selectedTextFan.SetActive(false);
            }
        }

        // Level 1
        else if (transform.localRotation.eulerAngles.z > 72 && transform.localRotation.eulerAngles.z < 144)
        { 
            previewedFrog = 2;

            if (chosenFrog == 1)
            {
                selectedTextA.SetActive(true);
                selectedTextBL.SetActive(false);
                selectedTextD.SetActive(false);
                selectedTextFan.SetActive(false);
            }
            else
            {
                selectedTextA.SetActive(false);
                selectedTextBL.SetActive(false);
                selectedTextD.SetActive(false);
                selectedTextFan.SetActive(false);
            }
        }

        else if (transform.localRotation.eulerAngles.z > 0 && transform.localRotation.eulerAngles.z < 72)
        { 
            previewedFrog = 1;

            selectedTextA.SetActive(false);
            selectedTextBL.SetActive(false);
            selectedTextD.SetActive(false);
            selectedTextFan.SetActive(false);
        }

        if (Input.GetButtonDown("Tongue"))
        {
            GameObject.Find("AudioManager").GetComponent<S_AudioManager>().ClickSFX();

            switch (previewedFrog)
            {
                case 1:
                    GameObject.Find("FrogManager").GetComponent<S_FrogManager>().choice = 1;

                    break;

                case 2:
                    GameObject.Find("FrogManager").GetComponent<S_FrogManager>().choice = 2;

                    break;

                case 3:
                    GameObject.Find("FrogManager").GetComponent<S_FrogManager>().choice = 3;

                    break;

                case 4:
                    GameObject.Find("FrogManager").GetComponent<S_FrogManager>().choice = 4;

                    break;
                case 5:
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
