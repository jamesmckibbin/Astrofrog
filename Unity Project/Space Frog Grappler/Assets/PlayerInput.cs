using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float turntableMod = 875000;
    [SerializeField] private float keyboardMod = 250;
    Gamepad gamepad = Gamepad.current;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        gamepad.SetMotorSpeeds(0, Mathf.Sin(Time.time*4.5f) + 0.2f); //Makes tongue button pulse
    }

    private void FixedUpdate()
    {
        if (!(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)))
            transform.eulerAngles += new Vector3(0, 0, (Input.GetAxisRaw("Vertical") * -turntableMod * Time.fixedDeltaTime));
        else
        {
            transform.eulerAngles += new Vector3(0, 0, (Input.GetAxisRaw("Vertical") * -keyboardMod * Time.fixedDeltaTime));
        }
        if(Input.GetButton("Tongue")) //Unity is having serious problems reading GetButtonDown (as in it's only reading like 1 in 10 presses), so I'm using GetButton for now.
                                      //Shouldn't be a problem, since the tongue ability already has an inherent cooldown.
        {
            //Some event stuff
        }

    }
}
