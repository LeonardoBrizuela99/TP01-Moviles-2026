using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TutorialMinigame : MonoBehaviour
{

    [SerializeField] private Vector2 playerMovement;
    [SerializeField] private float money = 0;
    [SerializeField] private bool isCorrect;
    [SerializeField] private int steps = 0;
    [SerializeField] private Animator animator;
    [SerializeField] private PedalButton botonIzquierda;
    [SerializeField] private PedalButton botonAbajo;
    [SerializeField] private PedalButton botonDerecha;
    [SerializeField] private float delayAfterFinish = 1.5f;
    [SerializeField] private string fallbackScene = "Gameplay";

    private bool finished = false;


    void Start()
    {
        bool isCorrect = false;

       
#if ANDROID_BUILD
        SetButtons(true);
#else
        SetButtons(false);
#endif
    }

    void Update()
    {
        if (finished) return;

#if ANDROID_BUILD
        float x = (botonDerecha.Pressed ? 1f : 0f) - (botonIzquierda.Pressed ? 1f : 0f);
        float y = botonAbajo.Pressed ? -1f : 0f;
        playerMovement = new Vector2(x, y);
#endif

        if (playerMovement.x < 0 && steps == 0)
        {
            Debug.Log("left");
            steps++;
            animator.SetInteger("Steps", 1);
            Debug.Log(steps);
        }
        if (playerMovement.x > 0 && steps == 2)
        {
            Debug.Log("right");
            steps++;
            animator.SetInteger("Steps", 3);
            Debug.Log(steps);
        }
        if (playerMovement.y < 0 && steps == 1)
        {
            Debug.Log("Down");
            steps++;
            animator.SetInteger("Steps", 2);
            Debug.Log(steps);
        }
        if (steps == 3)
        {
            
            finished = true;
            StartCoroutine(FinishTutorial());
        }
    }


    private void OnStep(InputValue action)
    {
        Vector2 value = action.Get<Vector2>();
        playerMovement = value;
        // Debug.Log(value);
    }

    private void SetButtons(bool active)
    {
        if (botonIzquierda != null) botonIzquierda.gameObject.SetActive(active);
        if (botonAbajo != null) botonAbajo.gameObject.SetActive(active);
        if (botonDerecha != null) botonDerecha.gameObject.SetActive(active);
    }

    private IEnumerator FinishTutorial()
    {
       
        yield return new WaitForSeconds(delayAfterFinish);

        if (GameModeManager.Instance != null)
        {
            GameModeManager.Instance.FinishTutorial();
        }
        else
        {
           
            SceneManager.LoadScene(fallbackScene);
        }
    }

}