using UnityEngine;

public class MoneyBagController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
             Debug.Log("hubo una colision");
             Destroy(gameObject);

        }
    }
}
