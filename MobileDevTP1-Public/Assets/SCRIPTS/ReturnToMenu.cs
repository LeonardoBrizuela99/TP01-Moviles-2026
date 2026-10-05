using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ReturnToMenu : MonoBehaviour
{
    [SerializeField] private string menuSceneName = "Menu";
    [SerializeField] private float delayBeforeMenu = 5f;

    private bool returning = false;

    void Start()
    {
        GameEvents.current.onScoreTimerFinish += OnGameFinished;
    }

    private void OnDestroy()
    {
        if (GameEvents.current != null)
        {
            GameEvents.current.onScoreTimerFinish -= OnGameFinished;
        }
    }

    private void OnGameFinished()
    {
        if (returning) return;
        returning = true;

        Debug.Log("Fin del juego, volviendo al menú en " + delayBeforeMenu + " segundos");
        StartCoroutine(WaitAndReturn());
    }

    private IEnumerator WaitAndReturn()
    {
     
        yield return new WaitForSecondsRealtime(delayBeforeMenu);
        GoToMenu();
    }

  
    public void GoToMenu()
    {
        if (GameModeManager.Instance != null)
        {
            GameModeManager.Instance.LoadMenu();
        }
        else
        {
        
            Time.timeScale = 1f;
            SceneManager.LoadScene(menuSceneName);
        }
    }
}