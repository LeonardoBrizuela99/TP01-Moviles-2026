using UnityEngine;
using UnityEngine.InputSystem;

public class BankMinigame : MonoBehaviour
{
   
    private Vector2 playerMovement;
    private float money = 0;
    private bool isCorrect;
    private int steps = 0;

    void Start()
    {
        bool isCorrect = false;
       
    }

    void Update()
    {
        
        if (playerMovement.x<0&& steps==0)
        {
            Debug.Log("left");
            steps++;
            Debug.Log(steps);
        }
        if (playerMovement.x > 0&&steps==2)
        {
            Debug.Log("right");
            steps++;
            Debug.Log(steps);
        }
        if (playerMovement.y < 0&&steps==1)
        {
            Debug.Log("Down");
            steps++;
            Debug.Log(steps);
        }
        if (steps==3)
        {
            steps = 0;
        }
    }

    void FixedUpdate()
    {

      
    }

    private void OnStep(InputValue action)
    {
        Vector2 value = action.Get<Vector2>();
        playerMovement = value;
        // Debug.Log(value);
    }
  
}
