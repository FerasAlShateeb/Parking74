using UnityEngine;

public class NotesSpawner : MonoBehaviour
{
    public GameObject[] notes;
    public GameObject objectToSpawn; // The GameObject you want to spawn
    public GameObject SpawnOB;
    private Transform[] spawnPoints;

    void Start()
    {
        FindSpawnPoints();
        SpawnAllNotes();
        objectToSpawn.SetActive(false);
    }

    void SpawnAllNotes()
    {
        for (int i = 0; i < notes.Length; i++)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            // Set the position and rotation of the note itself
            notes[i].transform.position = spawnPoint.position;
            notes[i].transform.rotation = spawnPoint.rotation;
            // Spawn the new object at the same position as the note
            GameObject spawnedObject = Instantiate(objectToSpawn, notes[i].transform.position, Quaternion.identity);

            // Set the rotation of the spawned object to face the sky
            Vector3 upDirection = Vector3.up;
            Vector3 toSky = -Vector3.up;
            Quaternion rotation = Quaternion.LookRotation(toSky, upDirection);
            spawnedObject.transform.rotation = rotation;

            // Set the note as the parent of the spawned object
            spawnedObject.transform.parent = notes[i].transform;
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
