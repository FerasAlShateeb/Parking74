using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwitch : MonoBehaviour
{
    public GameObject object01;
    public GameObject object02;
    private GameObject object03;
    private bool keyPickedUp = false;



    void Start()
    {
        object01.SetActive(false);
        object02.SetActive(false);
        // object03.SetActive(false);
    }




    void Update()
    {
        if(Input.GetButtonDown("1"))
        {
            object01.SetActive(true);
            object02.SetActive(false);
            // object03.SetActive(false);
        }

        if (Input.GetButtonDown("2") && keyPickedUp)
        {
            object01.SetActive(false);
            object02.SetActive(true);
            // object03.SetActive(false);
        }

        if (Input.GetButtonDown("3"))
        {
            object01.SetActive(false);
            object02.SetActive(false);
            // object03.SetActive(true);
        }

    }

    public void SetKeyPickedUp()
    {
        keyPickedUp = true;
    }
}
