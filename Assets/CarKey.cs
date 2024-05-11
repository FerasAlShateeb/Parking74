using System.Collections;
using UnityEngine;

public class CarKey : MonoBehaviour
{
    public GameObject CarKeys;
    public Animator animator;
    private Light indicatorLight;
    private Renderer indicatorRenderer;
    private Material originalMaterial;
    public Material redMaterial;

    void Start()
    {
        Transform Indicator = CarKeys.transform.Find("Indicator");
        if (Indicator != null)
        {
            indicatorRenderer = Indicator.GetComponent<Renderer>();
            if (indicatorRenderer != null)
            {
                originalMaterial = indicatorRenderer.material;
            }
            else
            {
                Debug.LogWarning("Indicator Renderer not found!");
            }
            indicatorLight = Indicator.GetComponent<Light>();
        }
        else
        {
            Debug.LogWarning("Indicator not found!");
        }
    }

    void Update()
    {
        // if(Input.GetButtonDown("flashlight"))
        // {
        //     if (indicatorRenderer != null && indicatorLight != null)
        //     {
        //         StartCoroutine(FlashIndicator());
        //     }
        // }
    }

    IEnumerator FlashIndicator()
    {
        indicatorLight.enabled = true;
        animator.SetTrigger("Panic");
        // Change material color to red
        indicatorRenderer.material = redMaterial;

        // Wait for 1 second
        yield return new WaitForSeconds(1.0f);
        // Revert material color back to original
        indicatorRenderer.material = originalMaterial;

        // Turn off the light
        indicatorLight.enabled = false;
        animator.SetBool("isPanic", false);
    }

    IEnumerator noIndicator()
    {
        animator.SetTrigger("Panic");

        // Wait for 1 second
        yield return new WaitForSeconds(1.0f);

        animator.SetBool("isPanic", false);
    }

    public void ActivateIndicator()
    {
        if (indicatorRenderer != null && indicatorLight != null)
        {
            StartCoroutine(FlashIndicator());
        }
    }

    // Method to deactivate the indicator light
    public void DeactivateIndicator()
    {
        StartCoroutine(noIndicator());
    }
}
