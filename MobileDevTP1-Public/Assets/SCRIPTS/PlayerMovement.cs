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
    [SerializeField] private SteeringWheel wheel;

    private void OnTriggerEnter(Collider other)
    {
        if (moneycount <= 3)
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
#if ANDROID_BUILD
        wheel.gameObject.SetActive(true);
#else
  wheel.gameObject.SetActive(false);
#endif
    }

    void Update()
    {

      
#if ANDROID_BUILD
        direccionMovimiento = new Vector3(wheel.TurnDir, 0f, 0f);
#else
        direccionMovimiento = new Vector3(playerMovement.x, 0f, playerMovement.y);
#endif

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
