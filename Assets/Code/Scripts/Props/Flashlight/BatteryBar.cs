using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryBar : MonoBehaviour
{
    private Image BatteryBarIM;
    public float CurrentBattery;
    private float MaxBattery = 100f;
    FlashlightAdvanced flashlight;





    void Start()
    {
        BatteryBarIM = GetComponent<Image>();
        flashlight = FindObjectOfType<FlashlightAdvanced>();

    }



    void Update()
    {
        CurrentBattery = flashlight.lifetime;
        BatteryBarIM.fillAmount = CurrentBattery / MaxBattery;

    }
}
