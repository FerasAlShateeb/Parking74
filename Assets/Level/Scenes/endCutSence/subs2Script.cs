using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class SubtitleController2 : MonoBehaviour
{
    public TMP_Text textBox;// Drag your Text component here in the inspector

    void Start()
    {
        StartCoroutine(WaitAndPrint());
    }

    IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(.5f);
        textBox.text = "Finaly i found my car";
        yield return new WaitForSeconds(2.5f);
        textBox.text = "Lets get out of here";
        yield return new WaitForSeconds(2.5f);
        textBox.text = "...";
        yield return new WaitForSeconds(2.5f);
        textBox.text = "Comming soon... Building 57.";

        NextScene();
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}
