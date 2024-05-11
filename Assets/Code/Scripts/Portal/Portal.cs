using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Portal : MonoBehaviour
{
    [SerializeField] Transform destination;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent<FirstPersonController>(out var player))
        {
            player.Teleport(destination.position, destination.transform);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(destination.position, .4f);
        var direcrtion = destination.TransformDirection(Vector3.forward);
        Gizmos.DrawRay(destination.position, direcrtion);
    }
}
