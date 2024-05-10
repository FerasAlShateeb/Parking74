using UnityEngine;

public class NotesSpawner : MonoBehaviour
{
    public GameObject[] notes;
    public GameObject SpawnOB;
    private Transform[] spawnPoints;
    private int count = 0;

    void Start()
    {
        FindSpawnPoints();
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

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            notes[count].transform.position = spawnPoints[spawnIndex].position;
            notes[count].transform.rotation = spawnPoints[spawnIndex].rotation;
        }
    }

    void FindSpawnPoints()
    {
        // Find all spawn points under NotesSpawnPoints
        Transform notesSpawnPoints = SpawnOB.transform;
        spawnPoints = new Transform[notesSpawnPoints.childCount];

        for (int i = 0; i < notesSpawnPoints.childCount; i++)
        {
            spawnPoints[i] = notesSpawnPoints.GetChild(i);
        }
    }
}
