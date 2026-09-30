using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float velocidad = 5f;
    private Rigidbody rb;
    private Vector3 direccionMovimiento;
    private Vector2 playerMovement;
    public float money = 0;
    public int moneycount = 0;


    private void OnTriggerEnter(Collider other)
    {
        if (moneycount<=3)
        {
            if (other.tag == "MoneyBag")
            {
                moneycount++;
                money += 100;
                Debug.Log(money);
                Debug.Log(moneycount);
            }
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
