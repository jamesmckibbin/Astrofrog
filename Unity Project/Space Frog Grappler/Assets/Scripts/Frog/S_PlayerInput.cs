using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Linq.Expressions;

public class S_PlayerInput : MonoBehaviour
{
    [SerializeField] private float turntableMod = 875000;
    [SerializeField] private float keyboardMod = 250;
    public static event Action FireTongue;
    public static event Action RetractTongue;

    public bool WaitForTongue = false;

    Gamepad gamepad = Gamepad.current;

    public Rigidbody2D rb;

    public Sprite playerSpriteIdle;
    public Sprite playerSpriteMove;
    public float mass;
    private SpriteRenderer spriteR;

    [SerializeField] private S_PauseOptions pauseOptions;

    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        playerSpriteIdle = GameObject.Find("FrogManager").GetComponent<S_FrogManager>().frogIdle;
        playerSpriteMove = GameObject.Find("FrogManager").GetComponent<S_FrogManager>().frogStretch;
        mass = GameObject.Find("FrogManager").GetComponent<S_FrogManager>().pullSpeed;

        spriteR.sprite = playerSpriteIdle;

        rb.mass = mass;
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseOptions.GamePaused == false)
        {
            if (gamepad != null)
                gamepad.SetMotorSpeeds(0, Mathf.Sin(Time.time * 4.5f) + 0.2f); //Makes tongue button pulse
            if (Input.GetButtonDown("Tongue"))
            {
                if (!WaitForTongue)
                {
                    FireTongue?.Invoke();
                    WaitForTongue = true;
                }
            }
            if (Input.GetButtonUp("Tongue"))
            {
                RetractTongue?.Invoke();
            }
            if (Input.GetButtonDown("Croak"))
            {
                GameObject.Find("AudioManager").GetComponent<S_AudioManager>().CroakSFX();
            }
            if (gameObject.GetComponent<Rigidbody2D>().velocity.magnitude >= 2.0)
            {
                spriteR.sprite = playerSpriteMove;
            }
            else if (gameObject.GetComponent<Rigidbody2D>().velocity.magnitude < 2.0)
            {
                spriteR.sprite = playerSpriteIdle;
            }
        }
    }

    private void FixedUpdate()
    {
        if (pauseOptions.GamePaused == false)
        {
            if (!(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
            {
                transform.eulerAngles += new Vector3(0, 0,
                    (Input.GetAxisRaw("Vertical") * -turntableMod * Time.fixedDeltaTime));
            }
            else
            {
                transform.eulerAngles +=
                    new Vector3(0, 0, (Input.GetAxisRaw("Vertical") * -keyboardMod * Time.fixedDeltaTime));
            }
        }
    }
    
}
