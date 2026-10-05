using UnityEngine;

public class MiniGameController : MonoBehaviour
{
    [SerializeField] private GameObject minigame;
    [SerializeField] private GameObject truck;
    [SerializeField] private PlayerMovement owner;

    void Start()
    {
        GameEvents.current.onMinigameTriggerEnter += OnMiniGameOpen;
        GameEvents.current.onMinigameTriggerExit += OnminiGameClose;
    }

    private void OnMiniGameOpen(PlayerMovement player)
    {
        if (player != owner) return;

        minigame.SetActive(true);
        truck.SetActive(false);
    }

    private void OnminiGameClose(PlayerMovement player)
    {
        if (player != owner) return;

        minigame.SetActive(false);
        truck.SetActive(true);
    }

    private void OnDestroy()
    {
        if (GameEvents.current == null) return;
        GameEvents.current.onMinigameTriggerEnter -= OnMiniGameOpen;
        GameEvents.current.onMinigameTriggerExit -= OnminiGameClose;
    }
}