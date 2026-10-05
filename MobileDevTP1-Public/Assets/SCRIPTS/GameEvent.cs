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

  
    public event Action<PlayerMovement> onMinigameTriggerEnter;
    public event Action<PlayerMovement> onMinigameTriggerExit;
    public event Action onScoreTimerFinish;
    // public event Action ScoreScreenExit;
    public void OnMinigameTriggerEnter(PlayerMovement player)
    {
        if (onMinigameTriggerEnter != null)
        {
            onMinigameTriggerEnter.Invoke(player);
        }
    }

    public void OnMinigameTriggerExit(PlayerMovement player)
    {
        if (onMinigameTriggerExit != null)
        {
            onMinigameTriggerExit.Invoke(player);
        }
    }

    public void OnScoreScreenEnter()
    {
        if (onScoreTimerFinish != null)
        {
            onScoreTimerFinish.Invoke();
        }
    }
}