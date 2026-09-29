using System.Collections;
using System.Data.SqlTypes;
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
    
    void Update()
    {
        if (truck.moneycount > 0)
        {
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
                truck.moneycount--;
                Debug.Log(truck.moneycount);
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
                steps = 0;
                StartCoroutine(WaitForReset());
            }
        }
        else
        {
            GameEvents.current.OnMinigameTriggerExit();
        }    
    }

    private void OnStep(InputValue action)
    {
        Vector2 value = action.Get<Vector2>();
        playerMovement = value;
        // Debug.Log(value);
    }
    private IEnumerator WaitForReset()
    {

        yield return new WaitForSeconds(1.0f);
        animator.SetInteger("Steps", 0);
        steps = 0;
    }

}
