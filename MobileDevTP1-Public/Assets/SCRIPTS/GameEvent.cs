using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;


    private void Awake()
    {
        current = this;
    }

    public event Action onMinigameTriggerEnter;
    public event Action onMinigameTriggerExit;
    public void OnMinigameTriggerEnter()
    {
        if (onMinigameTriggerEnter != null)
        {
            onMinigameTriggerEnter.Invoke();
        }
    }

    public void OnMinigameTriggerExit()
    {
        if (onMinigameTriggerExit != null)
        {
            onMinigameTriggerExit.Invoke();
        }
    }
}
