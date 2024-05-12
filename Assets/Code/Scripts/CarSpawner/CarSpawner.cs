using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CarSpawner : MonoBehaviour
{

    [SerializeField] private GameObject car;
    [SerializeField] private GameObject SpawnPoints;
    [SerializeField] private Transform parent;
    private bool isCar = false;


    // Start is called before the first frame update
    void Start()
    {
        Spawn(SpawnPoints.GetComponentInChildren<Transform>(), car);
    }

    private void Spawn(Transform spawnPoints, GameObject car)
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            int random = Random.Range(0, 776);

           
            Vector3 spawnPos = spawnPoint.position;

            GameObject tmp = Instantiate(car, spawnPos, spawnPoint.rotation, parent);
            tmp.SetActive(true);
            if (!isCar && random > 400)
            {
                isCar = true;
                Car script = tmp.GetComponent<Car>();

                if (script != null )
                {
                    script.enabled = true;
                }
            }
        }
    }
}
