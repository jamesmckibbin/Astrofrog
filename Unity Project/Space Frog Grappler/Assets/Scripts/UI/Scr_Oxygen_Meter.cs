using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_Oxygen_Meter : MonoBehaviour
{
    public float CurrentOxygen;
    public float MaxOxygenValue;
    public GameObject OxygenMeterBar;

    private Slider oxygenMeter;
    private float totalOxygenAdded;
    private float totalOxygenRemoved;

    private Color normalHealthColor = Color.cyan;
    private Color lowHealthColor = Color.red;

    // Grabs Slider component located on OxygenMeter
    void Start()
    {
        oxygenMeter = GetComponent<Slider>();
        CurrentOxygen = MaxOxygenValue;
    }

    // Adjusts the oxygen meter and sets the bar on the UI
    void Update()
    {
        if (CurrentOxygen < MaxOxygenValue * 0.33)
        {OxygenMeterBar.GetComponent<Image>().color = lowHealthColor;}

        else
        {OxygenMeterBar.GetComponent<Image>().color = normalHealthColor;}

        oxygenMeter.maxValue = MaxOxygenValue;
        CurrentOxygen = MaxOxygenValue + totalOxygenAdded - totalOxygenRemoved - Time.timeSinceLevelLoad;
        oxygenMeter.value = CurrentOxygen;
    }

    // Updates the maximum oxygen
    public void SetMaxOxygen(float newvalue)
    {MaxOxygenValue = newvalue;}

    // Adds oxygen to the bar
    public void AddOxygen(float value)
    {totalOxygenAdded += value;}

    // Removes oxygen from the bar
    public void RemoveOxygen(float value)
    {totalOxygenRemoved += value;}
}
