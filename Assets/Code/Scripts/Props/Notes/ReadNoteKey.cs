using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class ReadNoteKey : MonoBehaviour
{
    public GameObject player;
    public GameObject noteUI;
    public GameObject hud;
    public GameObject inv;

    public GameObject pickUpText;

    public AudioSource pickUpSound;
    public GameObject CarKeyModel;
    private ItemSwitch itemSwitch;
    private InventoryHotBarUI inventory;

    public bool inReach;



    void Start()
    {
        noteUI.SetActive(false);
        hud.SetActive(true);
        inv.SetActive(true);
        pickUpText.SetActive(false);

        inReach = false;
        
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
        if(Input.GetButtonDown("Interact") && inReach)
        {
            noteUI.SetActive(true);
            pickUpSound.Play();
            hud.SetActive(false);
            inv.SetActive(false);
            player.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if(Input.GetKeyDown(KeyCode.Escape) && noteUI.activeSelf)
        {
            ExitButton();
        }
        
    }


    public void ExitButton()
    {

        noteUI.SetActive(false);
        pickUpText.SetActive(false);
        hud.SetActive(true);
        inv.SetActive(true);
        player.GetComponent<FirstPersonController>().enabled = true;
        

        // Find and assign the InventoryHotBarUI script
        if (inventory == null)
        {
            inventory = FindObjectOfType<InventoryHotBarUI>();
            if (inventory == null)
            {
                Debug.LogError("InventoryHotBarUI script not found.");
                return; // Exit the method if script not found
            }
        }

        // Find and assign the ItemSwitch script
        if (itemSwitch == null)
        {
            itemSwitch = FindObjectOfType<ItemSwitch>();
            if (itemSwitch == null)
            {
                Debug.LogError("ItemSwitch script not found.");
            }
        }
        this.gameObject.SetActive(false);
        // Show the CarKey in the inventory
        inventory.ShowIcon("Box2", "CarKey");

        // Set the key as picked up
        itemSwitch.SetKeyPickedUp();

    }
}
