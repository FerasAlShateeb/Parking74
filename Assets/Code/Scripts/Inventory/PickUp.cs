using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public bool inReach;
    // public AudioSource pickSound;
    public GUI gui;


    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        gui.isPick = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            gui.isPick = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            inReach = true;
            gui.isPick = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            inReach = false;
            gui.isPick = false;

        }
    }
}
