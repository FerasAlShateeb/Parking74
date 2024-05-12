using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SubtitleController : MonoBehaviour
{
    public TMP_Text textBox;// Drag your Text component here in the inspector

    void Start()
    {
        StartCoroutine(WaitAndPrint());
    }

    IEnumerator WaitAndPrint()
    {
        textBox.text = "Under the cloak of night,"; // Display the first part of the subtitle
        yield return new WaitForSeconds(2);
        textBox.text = "a lone  student made his way"; 
        yield return new WaitForSeconds(1.5f);
        textBox.text = "through the deserted campus"; 
        yield return new WaitForSeconds(1.5f);
        textBox.text = "his footsteps echoing softly against the pavement. "; 
        yield return new WaitForSeconds(3f);
        textBox.text = "the dim glow of lampposts casting long shadows across the empty parking lot,"; 
        yield return new WaitForSeconds(6.4f);
        textBox.text = "shrouding it in an eerie stillness."; 
        yield return new WaitForSeconds(2.5f);
        textBox.text = "Parking lot 74 lay ahead"; 
        yield return new WaitForSeconds(3f);
        textBox.text = "a labyrinth of cars silently waiting in the darkness.";
        yield return new WaitForSeconds(3f);
        textBox.text = " ";
        // Update the text to the next part of the subtitle
    } 
}
