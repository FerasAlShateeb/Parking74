using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Cross;
    public GameObject Hand;
    public Boolean isPick;
    void Start()
    {
        isPick = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPick)
        {
            Cross.SetActive(false);
            Hand.SetActive(true);
        }
        else
        {
            Cross.SetActive(true);
            Hand.SetActive(false);
        }
    }
}
