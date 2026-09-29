using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TriggerArea : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        GameEvents.current.OnMinigameTriggerEnter();
    }

    private void OnTriggerExit(Collider other)
    {
        GameEvents.current.OnMinigameTriggerExit();
    }
}
