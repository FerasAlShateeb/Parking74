using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlashlightAdvanced : MonoBehaviour
{
    public Light light;
    public TMP_Text text;

    public TMP_Text batteryText;

    public float lifetime = 100;

    public float batteries = 0;

    public AudioSource flashON;
    public AudioSource flashOFF;
    public float delayTime;

    private bool on;
    private bool off;
    public GameObject flashlightModel;


    void Start()
    {
        light = GetComponent<Light>();
        off = true;
        light.enabled = false;
    }



    void Update()
    {
        text.text = lifetime.ToString("0") + "%";
        batteryText.text = batteries.ToString();
        bool flashExist = flashlightModel.activeSelf;
        if(!flashExist && on)
        {
            flashOFF.Play();
            light.enabled = false;
            on = false;
            off = true;
        }
        if(Input.GetButtonDown("flashlight") && off && flashExist)
        {
            StartCoroutine(TriggerFlash(true));
        }

        else if (Input.GetButtonDown("flashlight") && on && flashExist)
        {
            StartCoroutine(TriggerFlash(false));
        }

        if (on)
        {
            lifetime -= 1 * Time.deltaTime;
        }

        if(lifetime <= 0)
        {
            light.enabled = false;
            on = false;
            off = true;
            lifetime = 0;
        }

        if (lifetime >= 100)
        {
            lifetime = 100;
        }

        if (Input.GetButtonDown("reload") && batteries >= 1)
        {
            batteries -= 1;
            lifetime += 50;
        }

        if (Input.GetButtonDown("reload") && batteries == 0)
        {
            return;
        }

        if(batteries <= 0)
        {
            batteries = 0;
        }

    IEnumerator TriggerFlash(bool state)
    {
        yield return new WaitForSeconds(delayTime);
        if(state) //On or off
        {
            flashON.Play();
            light.enabled = true;
            on = true;
            off = false;
        }
        else
        {
            flashOFF.Play();
            light.enabled = false;
            on = false;
            off = true;
        }
        
    }


    }

}


