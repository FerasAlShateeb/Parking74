using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHotBarUI : MonoBehaviour
{
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;

    private GameObject currentSelectedItem;

    // Start is called before the first frame update
    void Start()
    {
        // Initially, no item is selected
        currentSelectedItem = null;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the user pressed keys 1 to 4
        if (Input.GetButtonDown("1"))
        {
            SelectItem(item1);
        }
        else if (Input.GetButtonDown("2"))
        {
            SelectItem(item2);
        }
        else if (Input.GetButtonDown("3"))
        {
            SelectItem(item3);
        }
        else if (Input.GetButtonDown("4"))
        {
            SelectItem(item4);
        }
    }

    void SelectItem(GameObject item)
    {
        if (item != null)
        {
            // Deactivate border of previously selected item
            if (currentSelectedItem != null)
            {
                Transform prevBorder = currentSelectedItem.transform.Find("Border");
                if (prevBorder != null)
                {
                    prevBorder.gameObject.SetActive(false);
                }
            }

            // Activate border of selected item
            Transform border = item.transform.Find("Border");
            if (border != null)
            {
                border.gameObject.SetActive(true);
            }
            else
            {
                Debug.LogError("Border child not found for item: " + item.name);
            }

            // Update current selected item
            currentSelectedItem = item;
        }
        else
        {
            Debug.LogError("Item is null.");
        }
    }

    public void ShowIcon(string name)
    {
        GameObject item = GameObject.Find(name);
        if (item != null)
        {
            GameObject itemObj = GameObject.Find("Keys");
            if(itemObj == null)
            {
                // Activate icon of selected item
                Transform icon = item.transform.Find("Icon");
                if (icon != null)
                {
                    icon.gameObject.SetActive(true);
                }
                else
                {
                    Debug.LogError("Border child not found for item: " + item.name);
                }
            }

        }
        else
        {
            Debug.LogError("Item is null.");
        }
    }
}
