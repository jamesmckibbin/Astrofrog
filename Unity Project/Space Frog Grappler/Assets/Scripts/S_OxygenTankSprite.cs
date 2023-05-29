using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_OxygenTankSprite : MonoBehaviour
{
    public Sprite tank;
    public Sprite idle;
    public Sprite fast;
    private SpriteRenderer spriteR;

    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        idle = GameObject.Find("FrogManager").GetComponent<S_FrogManager>().frogIdle;
        fast = GameObject.Find("FrogManager").GetComponent<S_FrogManager>().frogStretch;
        tank = GameObject.Find("FrogManager").GetComponent<S_FrogManager>().frogTank;

        spriteR.sprite = tank;
    }


}
