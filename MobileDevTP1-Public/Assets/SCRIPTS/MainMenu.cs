using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string singleSceneName = "Gameplay";
    [SerializeField] private string multiSceneName = "GameplayMultiplayer";
    [SerializeField] private GameObject creditScreen;
    [SerializeField] private GameObject optionScreen;

    public void PlaySingle()
    {
        if (GameModeManager.Instance != null)
        {
            GameModeManager.Instance.SetMode(GameModeManager.Mode.Single);
            GameModeManager.Instance.StartGame();
        }
        else
        {
            SceneManager.LoadScene(singleSceneName);
        }
    }

    public void PlayMulti()
    {
        if (GameModeManager.Instance != null)
        {
            GameModeManager.Instance.SetMode(GameModeManager.Mode.Multi);
            GameModeManager.Instance.StartGame();
        }
        else
        {
            SceneManager.LoadScene(multiSceneName);
        }
    }

    public void OpenCredits() { creditScreen.SetActive(true); }
    public void CloseCredits() { creditScreen.SetActive(false); }

    public void OpenOptions() { optionScreen.SetActive(true); }
    public void CloseOptions() { optionScreen.SetActive(false); }
}