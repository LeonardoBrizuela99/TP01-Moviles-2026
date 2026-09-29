using UnityEngine;

public class MiniGameController : MonoBehaviour
{
    [SerializeField] private GameObject minigame;
    [SerializeField] private GameObject truck;
    void Start()
    {
        GameEvents.current.onMinigameTriggerEnter+= OnMiniGameOpen;
        GameEvents.current.onMinigameTriggerExit += OnminiGameClose;
    }
    
    private void OnMiniGameOpen()
    {
        minigame.SetActive(true);
        truck.SetActive(false);
    }

    private void OnminiGameClose()
    {
        minigame.SetActive(false);
        truck.SetActive(true);
    }
    private void OnDestroy()
    {
        GameEvents.current.onMinigameTriggerEnter -= OnMiniGameOpen;
        GameEvents.current.onMinigameTriggerExit -= OnminiGameClose;
    }

}