using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickUp : MonoBehaviour
{
    private bool inReach;

    public GameObject pickUpText;
    public GameObject flashlight;

    public AudioSource pickUpSound;
    // public GUI gui;

    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        // if (gui == null)
        // {
        //     gui = FindObjectOfType<GUI>();
        //     if (gui == null)
        //     {
        //         Debug.LogError("GUI script not found in the scene.");
        //     }
        // }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpText.SetActive(true);
            // gui.isPick = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
            // gui.isPick = false;
        }
    }




    void Update()
    {
        if(Input.GetButtonDown("Interact") && inReach)
        {
            // gui.isPick = false;
            flashlight.GetComponent<FlashlightAdvanced>().batteries += 1;
            pickUpSound.Play();
            inReach = false;
            pickUpText.SetActive(false);
            Destroy(gameObject);
        }
        
    }
}
