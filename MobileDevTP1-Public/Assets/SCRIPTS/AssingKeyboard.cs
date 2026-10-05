using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class AssignKeyboard : MonoBehaviour
{
    [SerializeField] private string controlScheme = "Jugador1";

    void OnEnable()
    {
        StartCoroutine(Assign());
    }

    private IEnumerator Assign()
    {
       
        yield return null;

        PlayerInput playerInput = GetComponent<PlayerInput>();

        if (Keyboard.current != null)
        {
            playerInput.SwitchCurrentControlScheme(controlScheme, Keyboard.current);
        }
    }
}