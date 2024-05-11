using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteInteraction : MonoBehaviour
{
    public List<GameObject> noteUIs; // List of NoteUI GameObjects
    private int currentNoteIndex = 0; // Index of the current active NoteUI

    // Start is called before the first frame update
    void Start()
    {
        // Deactivate all NoteUIs initially
        foreach (GameObject noteUI in noteUIs)
        {
            noteUI.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ShowNextNoteUI()
    {
        if (currentNoteIndex < noteUIs.Count)
        {
            // Deactivate the previous NoteUI
            if (currentNoteIndex > 0)
            {
                noteUIs[currentNoteIndex - 1].SetActive(false);
            }

            // Activate the current NoteUI
            noteUIs[currentNoteIndex].SetActive(true);

            // Move to the next NoteUI
            currentNoteIndex++;
        }
    }

    public void HideNoteUI()
    {
        foreach (GameObject noteUI in noteUIs)
        {
            noteUI.SetActive(false);
        }
    }

    public bool AnyNoteUIActive()
    {
        foreach (GameObject noteUI in noteUIs)
        {
            if (noteUI.activeSelf)
            {
                return true;
            }
        }
        return false;
    }
}
