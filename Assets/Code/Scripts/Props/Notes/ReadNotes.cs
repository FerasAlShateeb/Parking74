using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ReadNotes : MonoBehaviour
{
    public GameObject player;
    public NoteInteraction noteInteraction; // Reference to the NoteInteraction script
    public GameObject hud;
    public GameObject inv;
    public GameObject pickUpText;
    public AudioSource pickUpSound;
    public bool inReach;
    private string name;
    public GameObject flashlight;

    void Start()
    {
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
            name = this.gameObject.name;
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
        if (Input.GetButtonDown("Interact") && inReach)
        {
            // Call the method from NoteInteraction to show the next NoteUI
            pickUpSound.Play();
            hud.SetActive(false);
            inv.SetActive(false);
            player.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            noteInteraction.ShowNextNoteUI(); // line 51
            this.gameObject.SetActive(false);
        }
    }

    public void ExitButton()
    {
        // Call the method from NoteInteraction to hide all NoteUIs
        noteInteraction.HideNoteUI();
        pickUpText.SetActive(false);
        hud.SetActive(true);
        inv.SetActive(true);
        player.GetComponent<FirstPersonController>().enabled = true;
        flashlight.GetComponent<FlashlightAdvanced>().batteries += 1;
    }
}
