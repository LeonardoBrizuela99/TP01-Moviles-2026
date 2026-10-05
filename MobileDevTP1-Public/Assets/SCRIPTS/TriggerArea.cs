using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TriggerArea : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponentInParent<PlayerMovement>();
        if (player == null) return;

        GameEvents.current.OnMinigameTriggerEnter(player);
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerMovement player = other.GetComponentInParent<PlayerMovement>();
        if (player == null) return;

        GameEvents.current.OnMinigameTriggerExit(player);
    }
}