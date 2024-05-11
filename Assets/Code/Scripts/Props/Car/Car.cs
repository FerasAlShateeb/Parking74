using UnityEngine;

public class Car : MonoBehaviour
{
    // Reference to the player GameObject
    public GameObject player;

    // Reference to the car key script
    public CarKey carKey;
    public GameObject KeyModel;

    // Distance at which the car sound is activated
    public float activationDistance = 200f;

    // Audio source for the car sound
    public AudioSource carSrc;

    void Start()
    {
        // Get the AudioSource component attached to the car
    }

    void Update()
    {
        // Check if the player is pressing the "flashlight" button
        if (Input.GetButtonDown("flashlight"))
        {
            // Check the distance between the player and the car
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            // Activate car sound if the player is within the activation distance
            Debug.Log("Distance is " + distanceToPlayer);
            if ((distanceToPlayer <= activationDistance) && KeyModel.activeSelf)
            {
                if (carSrc != null)
                {
                    Debug.Log("Sound should be pl");
                    carSrc.Play();
                }

                // Activate car key indicator
                if (carKey != null)
                {
                    carKey.ActivateIndicator();
                }
            }
            else
            {
                if (carKey != null && (KeyModel.activeSelf))
                {
                    carKey.DeactivateIndicator();
                }
            }
        }
    }
}
