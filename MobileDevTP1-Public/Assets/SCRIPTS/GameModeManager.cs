using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeManager : MonoBehaviour
{
    public static GameModeManager Instance { get; private set; }

    public enum Mode { Single, Multi }
    public Mode CurrentMode { get; private set; } = Mode.Single;

    // Es true una vez que se completó el tutorial (se reinicia al cerrar el juego)
    public bool TutorialDone { get; private set; } = false;

    [SerializeField] private string menuSceneName = "Menu";
    [SerializeField] private string tutorialSceneName = "Tutorial";
    [SerializeField] private string singleSceneName = "Gameplay";
    [SerializeField] private string multiSceneName = "GameplayMultiplayer";

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetMode(Mode mode)
    {
        CurrentMode = mode;
    }

    // Si el tutorial no se hizo todavía, va al tutorial. Si ya se hizo, va directo al juego.
    public void StartGame()
    {
        if (!TutorialDone)
        {
            SceneManager.LoadScene(tutorialSceneName);
        }
        else
        {
            LoadGameScene();
        }
    }

    // Se llama cuando termina el tutorial: lo marca como hecho y pasa al juego.
    public void FinishTutorial()
    {
        TutorialDone = true;
        LoadGameScene();
    }

    // Vuelve al menú principal. Al cargar la escena de nuevo, todo se reinicia.
    public void LoadMenu()
    {
        Time.timeScale = 1f; // por si el juego estaba pausado
        SceneManager.LoadScene(menuSceneName);
    }

    private void LoadGameScene()
    {
        string scene = CurrentMode == Mode.Single ? singleSceneName : multiSceneName;
        SceneManager.LoadScene(scene);
    }
}