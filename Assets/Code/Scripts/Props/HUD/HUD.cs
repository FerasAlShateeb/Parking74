using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject flashLightON;
    public GameObject flashLightOFF;
    public GameObject flashLightOB;
    private Light flashLightComponent;

    void Start()
    {
        flashLightON.SetActive(false);
        flashLightComponent = flashLightOB.GetComponent<Light>();
    }

    void Update()
    {
        if(flashLightComponent.enabled)
        {
            flashLightON.SetActive(true);
            flashLightOFF.SetActive(false);
        }
        
        else
        {
            flashLightON.SetActive(false);
            flashLightOFF.SetActive(true);
        }

    }
}
