using UnityEngine;
using UnityEngine.Video;

public class SlenderManAI : MonoBehaviour
{
    public Transform player; 
    public float teleportDistance = 10f; 
    public float teleportCooldown = 5f; 
    public float returnCooldown = 10f; 
    [Range(0f, 1f)] public float chaseProbability = 1f;
    public float rotationSpeed = 5f; 
    public AudioClip teleportSound;
    private AudioSource audioSource;

    public GameObject staticObject;
    public float staticActivationRange = 15f; 

    private Vector3 baseTeleportSpot;
    private float teleportTimer;
    private bool returningToBase;


    private void Start()
    {
        baseTeleportSpot = transform.position;
        teleportTimer = teleportCooldown;

        
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        
        audioSource.clip = teleportSound;

        
        if (staticObject != null)
        {
            staticObject.SetActive(false);
        }

        
    }

    private void Update()
    {

        if (player == null)
        {
           
            return;
        }

        

        teleportTimer -= Time.deltaTime;

        if (teleportTimer <= 0f)
        {
            if (returningToBase)
            {
                TeleportToBaseSpot();
                teleportTimer = returnCooldown;
                returningToBase = false;
            }
            else
            {
                DecideTeleportAction();
                teleportTimer = teleportCooldown;
            }
        }

        RotateTowardsPlayer();

        
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= staticActivationRange)
        {
            if (staticObject != null && !staticObject.activeSelf)
            {
                staticObject.SetActive(true);
            }
        }
        else
        {
            if (staticObject != null && staticObject.activeSelf)
            {
                staticObject.SetActive(false);
            }
        }
    }

    private void DecideTeleportAction()
    {
        float randomValue = Random.value;

        if (randomValue <= chaseProbability)
        {
            TeleportNearPlayer();
        }
        else
        {
            TeleportToBaseSpot();
        }
    }

    private void TeleportNearPlayer()
    {
        Vector3 randomPosition = player.position + Random.onUnitSphere * teleportDistance;
        randomPosition.y = transform.position.y; 
        transform.position = randomPosition;

        
        // audioSource.Play();
    }

    private void TeleportToBaseSpot()
    {
        transform.position = baseTeleportSpot;
        returningToBase = true;

      
        // audioSource.Play();
    }

    private void RotateTowardsPlayer()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.y = 0f;

        if (directionToPlayer != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

}
