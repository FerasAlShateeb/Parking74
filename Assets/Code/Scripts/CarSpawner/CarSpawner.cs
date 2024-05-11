using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CarSpawner : MonoBehaviour
{

    [SerializeField] private GameObject car;
    [SerializeField] private GameObject SpawnPoints;
    private List<Transform> rotations = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        setRotations();
        Spawn(SpawnPoints.GetComponentInChildren<Transform>(), car);
    }

    private void Spawn(Transform spawnPoints, GameObject car)
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            Vector3 spawnPos = spawnPoint.position;
            Debug.LogWarning(spawnPoint.name);

            Instantiate(car, spawnPos, car.transform.rotation);
        }
    }

    private void setRotations()
    {
        rotations.Add(car.transform);

        

    }
}
