using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ProximityTrigger : MonoBehaviour
{
    public GameObject player;
    public VideoPlayer videoPlayer;
    public float proximityDistance = 15f;
    private float timeClose = 0f;

    private void Update()
    {
        if (!player.activeInHierarchy || !gameObject.activeInHierarchy)
        {
            
            return;
        }

        float distance = Vector3.Distance(transform.position, player.transform.position);
       

        if (distance <= proximityDistance)
        {
            timeClose += Time.deltaTime;
           

            if (timeClose >= 5f)
            {
               
                videoPlayer.Play();
                StartCoroutine(WaitAndRestart((float)videoPlayer.length));
            }
        }
        else
        {
            timeClose = 0f; 
            
        }
    }

    private IEnumerator WaitAndRestart(float delay)
    {
       
        yield return new WaitForSeconds(delay);
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
