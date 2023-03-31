using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_Oxygen_Meter : MonoBehaviour
{
    public float OxygenValue;

    private Slider oxygenMeter;
    private float maxOxygenValue = 120;
    private float totalOxygenAdded = 0;
    private float totalOxygenRemoved = 0;

    // Grabs Slider component located on OxygenMeter
    void Start()
    {
        oxygenMeter = GetComponent<Slider>();
        OxygenValue = maxOxygenValue;
    }

    // Adjusts the oxygen meter and sets the bar on the UI
    void Update()
    {
        oxygenMeter.maxValue = maxOxygenValue;
        OxygenValue = maxOxygenValue + totalOxygenAdded - totalOxygenRemoved - Time.timeSinceLevelLoad;
        oxygenMeter.value = OxygenValue;
    }

    // Updates the maximum oxygen
    public void SetMaxOxygen(float newvalue)
    {
        maxOxygenValue = newvalue;
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
}
