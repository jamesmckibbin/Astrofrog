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

    public GameObject infoTextA;
    public GameObject infoTextBl;
    public GameObject infoTextFan;
    public GameObject infoTextD;

    [SerializeField] private float turntableMod = 875000;
    [SerializeField] private float keyboardMod = 250;
    Gamepad gamepad = Gamepad.current;

    public int previewedFrog;
    public int chosenFrog;

    void Update()
    {
        if (gamepad != null)
            gamepad.SetMotorSpeeds(0, Mathf.Sin(Time.time * 4.5f) + 0.2f); //Makes tongue button pulse

        if (transform.localRotation.eulerAngles.z > 235 && transform.localRotation.eulerAngles.z < 305)
        { 
            previewedFrog = 4;

            infoTextA.SetActive(false);
            infoTextBl.SetActive(false);
            infoTextFan.SetActive(false);
            infoTextD.SetActive(true);

            if (chosenFrog == 4)
            {
                selectedTextA.SetActive(false);
                selectedTextBL.SetActive(false);
                selectedTextFan.SetActive(false);
                selectedTextD.SetActive(true);
            }
            else
            {
                selectedTextA.SetActive(false);
                selectedTextBL.SetActive(false);
                selectedTextFan.SetActive(false);
                selectedTextD.SetActive(false);
            }
        }

        else if (transform.localRotation.eulerAngles.z > 160 && transform.localRotation.eulerAngles.z < 235)
        { 
            previewedFrog = 3;

            infoTextA.SetActive(false);
            infoTextBl.SetActive(false);
            infoTextFan.SetActive(true);
            infoTextD.SetActive(false);

            if (chosenFrog == 3)
            {
                selectedTextA.SetActive(false);
                selectedTextBL.SetActive(false);
                selectedTextFan.SetActive(true);
                selectedTextD.SetActive(false);
            }
            else
            {
                selectedTextA.SetActive(false);
                selectedTextBL.SetActive(false);
                selectedTextFan.SetActive(false);
                selectedTextD.SetActive(false);
            }
        }

        else if (transform.localRotation.eulerAngles.z > 90 && transform.localRotation.eulerAngles.z < 160)
        { 
            previewedFrog = 2;

            infoTextA.SetActive(false);
            infoTextBl.SetActive(true);
            infoTextFan.SetActive(false);
            infoTextD.SetActive(false);

            if (chosenFrog == 2)
            {
                selectedTextA.SetActive(false);
                selectedTextBL.SetActive(true);
                selectedTextFan.SetActive(false);
                selectedTextD.SetActive(false);
            }
            else
            {
                selectedTextA.SetActive(false);
                selectedTextBL.SetActive(false);
                selectedTextFan.SetActive(false);
                selectedTextD.SetActive(false);
            }
        }

        else if (transform.localRotation.eulerAngles.z > 20 && transform.localRotation.eulerAngles.z < 90)
        { 
            previewedFrog = 1;

            infoTextA.SetActive(true);
            infoTextBl.SetActive(false);
            infoTextFan.SetActive(false);
            infoTextD.SetActive(false);

            if (chosenFrog == 1)
            {
                selectedTextA.SetActive(true);
                selectedTextBL.SetActive(false);
                selectedTextFan.SetActive(false);
                selectedTextD.SetActive(false);
            }
            else
            {
                selectedTextA.SetActive(false);
                selectedTextBL.SetActive(false);
                selectedTextFan.SetActive(false);
                selectedTextD.SetActive(false);
            }
        }

        else if (transform.localRotation.eulerAngles.z > 20 || transform.localRotation.eulerAngles.z < 305)
        { 
            previewedFrog = 5;

            infoTextA.SetActive(false);
            infoTextBl.SetActive(false);
            infoTextFan.SetActive(false);
            infoTextD.SetActive(false);

            selectedTextA.SetActive(false);
            selectedTextBL.SetActive(false);
            selectedTextFan.SetActive(false);
            selectedTextD.SetActive(false);
        }

        if (Input.GetButtonDown("Tongue"))
        {
            GameObject.Find("AudioManager").GetComponent<S_AudioManager>().ClickSFX();

            switch (previewedFrog)
            {
                case 1:
                    GameObject.Find("FrogManager").GetComponent<S_FrogManager>().choice = 1;
                    chosenFrog = 1;

                    selectedTextA.SetActive(true);
                    selectedTextBL.SetActive(false);
                    selectedTextFan.SetActive(false);
                    selectedTextD.SetActive(false);
                    break;

                case 2:
                    GameObject.Find("FrogManager").GetComponent<S_FrogManager>().choice = 2;
                    chosenFrog = 2;

                    selectedTextA.SetActive(false);
                    selectedTextBL.SetActive(true);
                    selectedTextFan.SetActive(false);
                    selectedTextD.SetActive(false);
                    break;

                case 3:
                    GameObject.Find("FrogManager").GetComponent<S_FrogManager>().choice = 3;
                    chosenFrog = 3;

                    selectedTextA.SetActive(false);
                    selectedTextBL.SetActive(false);
                    selectedTextFan.SetActive(true);
                    selectedTextD.SetActive(false);
                    break;

                case 4:
                    GameObject.Find("FrogManager").GetComponent<S_FrogManager>().choice = 4;
                    chosenFrog = 4;

                    selectedTextA.SetActive(false);
                    selectedTextBL.SetActive(false);
                    selectedTextFan.SetActive(false);
                    selectedTextD.SetActive(true);
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
