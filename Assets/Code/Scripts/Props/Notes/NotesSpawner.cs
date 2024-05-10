using UnityEngine;

public class NotesSpawner : MonoBehaviour
{
    public GameObject[] notes;
    private int count = 0;

    void Start()
    {

    }

    void Update()
    {
        // Check if all notes are activated
        if (count < notes.Length)
        {
            // Activate next note if it's not active
            if (!notes[count].activeInHierarchy)
            {
                ActivateNextNote();
            }
        }
    }

    void ActivateNextNote()
    {
        if((count+1) != notes.Length)
        {
            count++;
            notes[count].SetActive(true);
        }
    }
}
