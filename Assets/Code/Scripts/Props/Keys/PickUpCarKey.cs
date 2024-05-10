using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCarKey : MonoBehaviour
{
    public GameObject keyOB;
    public GameObject CarKeyModel;
    public GameObject pickUpText;
    public AudioSource keySound;
    public ItemSwitch itemSwitch;
    private InventoryHotBarUI inventory;


    public bool inReach;


    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        if (inventory == null)
        {
            inventory = FindObjectOfType<InventoryHotBarUI>();
            if (inventory == null)
            {
                Debug.LogError("Invetory script not found in the scene.");
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }


    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            keyOB.SetActive(false);
            keySound.Play();
            pickUpText.SetActive(false);
            inventory.ShowIcon("Box2", this.gameObject.name);
            itemSwitch.SetKeyPickedUp();
        }  
    }
}
