using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Scr_Player_Input : MonoBehaviour
{
    [SerializeField] private float turntableMod = 875000;
    [SerializeField] private float keyboardMod = 250;
    public static event Action FireTongue;
    public static event Action RetractTongue;
    Gamepad gamepad = Gamepad.current;

    // Update is called once per frame
    void Update()
    {
        if (gamepad != null)
            gamepad.SetMotorSpeeds(0, Mathf.Sin(Time.time*4.5f) + 0.2f); //Makes tongue button pulse

        if(Input.GetButtonDown("Tongue"))
        {FireTongue?.Invoke();}

        if (Input.GetButtonUp("Tongue"))
        {RetractTongue?.Invoke();}
    }

    private void FixedUpdate()
    {
        if (!(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
            transform.eulerAngles += new Vector3(0, 0, (Input.GetAxisRaw("Vertical") * -turntableMod * Time.fixedDeltaTime));

        else
        {transform.eulerAngles += new Vector3(0, 0, (Input.GetAxisRaw("Vertical") * -keyboardMod * Time.fixedDeltaTime));}
    }
}
