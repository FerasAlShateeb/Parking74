using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{

    [SerializeField] private GameObject car;
    [SerializeField] private GameObject SpawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        Spawn(SpawnPoints.GetComponentInChildren<Transform>(), car);
    }

    private void Spawn(Transform spawnPoints, GameObject car)
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            Vector3 spawnPos = spawnPoint.position;

            Instantiate(car, spawnPos, car.transform.rotation);
        }
    }
}
