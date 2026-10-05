using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class BankMinigame : MonoBehaviour
{
    [SerializeField] private Vector2 playerMovement;
    [SerializeField] private float money = 0;
    [SerializeField] private bool isCorrect;
    [SerializeField] private int steps = 0;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovement truck;
    [SerializeField] private PedalButton botonIzquierda;
    [SerializeField] private PedalButton botonAbajo;
    [SerializeField] private PedalButton botonDerecha;


    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private string actionName = "Step";

    private InputAction stepAction;
    private bool closed = false;

    void Start()
    {
#if ANDROID_BUILD
        botonIzquierda.gameObject.SetActive(true);
        botonAbajo.gameObject.SetActive(true);
        botonDerecha.gameObject.SetActive(true);
#else
        botonIzquierda.gameObject.SetActive(false);
        botonAbajo.gameObject.SetActive(false);
        botonDerecha.gameObject.SetActive(false);
#endif
    }

    void OnEnable()
    {
        closed = false;
        steps = 0;
        if (animator != null) animator.SetInteger("Steps", 0);

        if (playerInput != null)
            stepAction = playerInput.actions.FindAction(actionName);
    }

    void Update()
    {
#if ANDROID_BUILD
        float x = (botonDerecha.Pressed ? 1f : 0f) - (botonIzquierda.Pressed ? 1f : 0f);
        float y = botonAbajo.Pressed ? -1f : 0f;
        playerMovement = new Vector2(x, y);
#else
        if (stepAction != null)
            playerMovement = stepAction.ReadValue<Vector2>();
#endif

        if (truck.moneycount > 0)
        {
            if (playerMovement.x < 0 && steps == 0)
            {
                steps++;
                animator.SetInteger("Steps", 1);
            }
            if (playerMovement.y < 0 && steps == 1)
            {
                steps++;
                animator.SetInteger("Steps", 2);
            }
            if (playerMovement.x > 0 && steps == 2)
            {
                steps++;
                animator.SetInteger("Steps", 3);
                truck.moneycount--;
            }
            if (steps == 3)
            {
                steps = 0;
                StartCoroutine(WaitForReset());
            }
        }
        else if (!closed)
        {
            closed = true;
            GameEvents.current.OnMinigameTriggerExit(truck);
        }
    }


    private void OnStep(InputValue action)
    {
        playerMovement = action.Get<Vector2>();
    }

    private IEnumerator WaitForReset()
    {
        yield return new WaitForSeconds(1.0f);
        animator.SetInteger("Steps", 0);
        steps = 0;
    }
}