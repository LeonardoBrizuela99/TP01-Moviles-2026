using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    private Rigidbody rb;
    private Vector3 direccionMovimiento;
    private Vector2 playerMovement;
    private float money = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="MoneyBag")
        {
            money += 100;
            Debug.Log(money);
        }
        
    }
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
      
        direccionMovimiento = new Vector3(playerMovement.x, 0f, playerMovement.y);
    }

    void FixedUpdate()
    {

        rb.MovePosition(rb.position + direccionMovimiento * velocidad * Time.fixedDeltaTime);
    }

    private void OnMove(InputValue action)
    {
        Vector2 value = action.Get<Vector2>();
        playerMovement = value;
       // Debug.Log(value);
    }
}
