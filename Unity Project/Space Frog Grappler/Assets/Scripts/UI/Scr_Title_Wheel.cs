using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Scr_Title_Wheel : MonoBehaviour
{
    public Scr_Scene_Switcher SceneSwitcher;
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
            print(transform.localEulerAngles.z);
            // Start
            if (transform.localRotation.eulerAngles.z > 270 && transform.localRotation.eulerAngles.z < 360)
            {
                print("start");
                StartCoroutine(SceneSwitcher.LoadScene(SceneIndexes.Level_1));
            }
            // Exit
            else if (transform.localRotation.eulerAngles.z > 180 && transform.localRotation.eulerAngles.z < 270)
            {
                print("quit");
                Application.Quit();
            }
            // Levels
            else if (transform.localRotation.eulerAngles.z > 90 && transform.localRotation.eulerAngles.z < 180)
            {
                print("levels");
                StartCoroutine(SceneSwitcher.LoadScene(SceneIndexes.SelectLevel));
            }
            // Credits
            else if (transform.localRotation.eulerAngles.z > 0 && transform.localRotation.eulerAngles.z < 90)
            {
                print("credits");
                StartCoroutine(SceneSwitcher.LoadScene(SceneIndexes.Credits));
            }
        }
    }

    private void FixedUpdate()
    {
        if (!(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
            transform.eulerAngles += new Vector3(0, 0, (Input.GetAxisRaw("Vertical") * -turntableMod * Time.fixedDeltaTime));

        else
        { transform.eulerAngles += new Vector3(0, 0, (Input.GetAxisRaw("Vertical") * -keyboardMod * Time.fixedDeltaTime)); }
    }
}
