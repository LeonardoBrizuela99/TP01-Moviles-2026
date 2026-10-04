using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float velocidad = 5f;
    public float aceleracion = 4f;
    public float desaceleracion = 3f;
    public float velocidadGiro = 90f;
    private float velocidadActual = 0f;
    private Rigidbody rb;
    private Vector3 direccionMovimiento;
    private Vector2 playerMovement;
    public float money = 0;
    public int moneycount = 0;
    //public onGas=0;
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
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
#if ANDROID_BUILD
        wheel.gameObject.SetActive(true);
#else
        wheel.gameObject.SetActive(false);
#endif
    }

    void Update()
    {

      
#if ANDROID_BUILD
        direccionMovimiento = new Vector3(wheel.TurnDir, 0f, 1f);
#else
        direccionMovimiento = new Vector3(playerMovement.x, 0f, playerMovement.y);
#endif

    }

    void FixedUpdate()
    {
        
        float objetivo = direccionMovimiento.z * velocidad;
        if (direccionMovimiento.z < 0f) objetivo *= 0.5f;
        float cambio = direccionMovimiento.z == 0f ? desaceleracion : aceleracion;
        velocidadActual = Mathf.MoveTowards(velocidadActual, objetivo, cambio * Time.fixedDeltaTime);

       
        float giro = direccionMovimiento.x * velocidadGiro * Mathf.Clamp(velocidadActual / velocidad, -1f, 1f) * Time.fixedDeltaTime;
        Quaternion nuevaRotacion = rb.rotation * Quaternion.Euler(0f, giro, 0f);
        rb.MoveRotation(nuevaRotacion);

       
        rb.MovePosition(rb.position + nuevaRotacion * Vector3.forward * velocidadActual * Time.fixedDeltaTime);
    }

    private void OnMove(InputValue action)
    {
        Vector2 value = action.Get<Vector2>();
        playerMovement = value;
        // Debug.Log(value);
    }
}