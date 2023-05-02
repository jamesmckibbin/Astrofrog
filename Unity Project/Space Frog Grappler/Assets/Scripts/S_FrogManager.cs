using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_FrogManager : MonoBehaviour
{
    private FrogData currentFrog;

    public FrogData astroFrog;
    public FrogData blastroFrog;
    public FrogData gastroFrog;
    public FrogData dastroFrog;

    public int choice = 0;

    public float tongueSpeed;
    public float pullSpeed;
    public Sprite frogIdle;
    public Sprite frogStretch;

    private static S_FrogManager instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
            return;
        }
    }

    void FixedUpdate()
    {
        switch(choice)
        {
            case 1:
                currentFrog = astroFrog;
                updateFrog();
                break;
            case 2:
                currentFrog = blastroFrog;
                updateFrog();
                break;
            case 3:
                currentFrog = gastroFrog;
                updateFrog();
                break;

            case 4:
                currentFrog = dastroFrog;
                updateFrog();
                break;
            default:
                break;
        }
    }

    void updateFrog()
    {
        tongueSpeed = currentFrog.tongueSpeed;
        pullSpeed = currentFrog.pullSpeed;
        frogIdle = currentFrog.frogIdle;
        frogStretch = currentFrog.frogStretch;
    }
}
