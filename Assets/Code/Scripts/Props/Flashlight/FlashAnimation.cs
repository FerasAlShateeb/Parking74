using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashAnimation : MonoBehaviour
{
    public Animator flashlightAnimator;

    // Duration of the "on" animation in seconds
    public float onAnimationDuration = 1.0f;

    // Update is called once per frame
    void Update()
    {
        // Check if the user presses the "F" key
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Trigger the "on" animation directly
            flashlightAnimator.SetTrigger("On");

            // Start coroutine to transition back to idle after the animation duration
            StartCoroutine(ReturnToIdle());
        }
    }

    IEnumerator ReturnToIdle()
    {
        // Wait for the duration of the "on" animation
        yield return new WaitForSeconds(onAnimationDuration);

        // Set the animator parameter to transition back to the "idle" state
        flashlightAnimator.SetTrigger("Idle");
    }
}
