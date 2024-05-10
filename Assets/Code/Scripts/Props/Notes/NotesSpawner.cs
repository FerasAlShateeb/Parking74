using UnityEngine;

public class NotesSpawner : MonoBehaviour
{
    public GameObject[] notes;
    public GameObject SpawnOB;
    private Transform[] spawnPoints;

    void Start()
    {
        FindSpawnPoints();
        SpawnAllNotes();
    }

    void SpawnAllNotes()
    {
        for (int i = 0; i < notes.Length; i++)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            notes[i].transform.position = spawnPoints[spawnIndex].position;
            notes[i].transform.rotation = spawnPoints[spawnIndex].rotation;
            notes[i].SetActive(true);
        }
    }

    void FindSpawnPoints()
    {
        Transform notesSpawnPoints = SpawnOB.transform;
        spawnPoints = new Transform[notesSpawnPoints.childCount];

        for (int i = 0; i < notesSpawnPoints.childCount; i++)
        {
            spawnPoints[i] = notesSpawnPoints.GetChild(i);
        }
    }
}
