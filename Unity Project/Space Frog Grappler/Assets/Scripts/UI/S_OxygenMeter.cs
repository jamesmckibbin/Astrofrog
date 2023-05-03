using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class S_OxygenMeter : MonoBehaviour
{
    public float CurrentOxygen;
    public float MaxOxygenValue;
    public GameObject OxygenMeterBar;
    public TextMeshProUGUI text;
    public float count = 0f;
    public int seconds;
    public bool beepSlow = false;
    public bool beepFast = false;

    private Slider oxygenMeter;
    private float totalOxygenAdded;
    private float totalOxygenRemoved;

    private Color normalHealthColor = Color.cyan;
    private Color lowHealthColor = Color.red;
    private float gradientPos;

    // Grabs Slider component located on OxygenMeter
    void Start()
    {
        oxygenMeter = GetComponent<Slider>();
        CurrentOxygen = MaxOxygenValue;
        text.text = MaxOxygenValue.ToString();
    }

    // Adjusts the oxygen meter and sets the bar on the UI
    void Update()
    {
        if (CurrentOxygen <= 0)
        {
            CurrentOxygen = 0;
            GameObject.Find("ButtonManager").GetComponent<S_ButtonManager>().GoToGameOver();
        }

        else if (CurrentOxygen < MaxOxygenValue * 0.2)
        {
            OxygenMeterBar.GetComponent<Image>().color = lowHealthColor;
        }

        else if(CurrentOxygen < MaxOxygenValue * 0.3)
        {
            beepSlow = true;
            beepFast = false;
        }

        else if (CurrentOxygen < MaxOxygenValue * 0.7)
        {
            gradientPos = (CurrentOxygen / MaxOxygenValue) - 0.2f;

            OxygenMeterBar.GetComponent<Image>().color = Color.HSVToRGB(0 + gradientPos, 1, 1);
            beepSlow = false;
            beepFast = false;
        }

        else
        {
            OxygenMeterBar.GetComponent<Image>().color = normalHealthColor;
            beepSlow = false;
            beepFast = false;
        }

        if (CurrentOxygen < MaxOxygenValue * 0.12)
        {
            beepSlow = false;
            beepFast = true;
        }

        oxygenMeter.maxValue = MaxOxygenValue;
        CurrentOxygen = MaxOxygenValue + totalOxygenAdded - totalOxygenRemoved - Time.timeSinceLevelLoad;
        oxygenMeter.value = CurrentOxygen;
        text.text = Mathf.Round(CurrentOxygen).ToString();

        count += Time.deltaTime;
        seconds = (int)count % 60;

        OxygenBeep();
    }

    // Updates the maximum oxygen
    public void SetMaxOxygen(float newvalue)
    {
        MaxOxygenValue = newvalue;
    }

    // Adds oxygen to the bar
    public void AddOxygen(float value)
    {
        totalOxygenAdded += value;
    }

    // Removes oxygen from the bar
    public void RemoveOxygen(float value)
    {
        totalOxygenRemoved += value;
    }

    void OxygenBeep()
    {
        if (seconds == 5  && beepSlow == true && beepFast == false)
        {
            GameObject.Find("AudioManager").GetComponent<S_AudioManager>().OxygenBeepSFX();
            count = 0;
            seconds = 0;
        }
        else if(seconds == 1 && beepFast == true && beepSlow == false)
        {
            GameObject.Find("AudioManager").GetComponent<S_AudioManager>().OxygenBeepSFX();
            count = 0;
            seconds = 0;
        }
        else if (seconds > 6)
        {
            count = 0;
            seconds = 0;
        }
    }
}
