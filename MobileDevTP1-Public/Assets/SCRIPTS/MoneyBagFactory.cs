using UnityEngine;

public class MoneyBagFactory : MonoBehaviour
{
    [SerializeField] private GameObject moneyBagPrefab;
    [SerializeField] private Transform[] puntosDeSpawn;
    [SerializeField] private bool crearAlInicio = true;

    void Start()
    {
        if (crearAlInicio)
        {
            CrearEnTodosLosPuntos();
        }
    }

    public GameObject CrearBolsa(Vector3 posicion)
    {
        GameObject bolsa = Instantiate(moneyBagPrefab, posicion, moneyBagPrefab.transform.rotation);
        bolsa.SetActive(true);
        bolsa.tag = "MoneyBag";
        return bolsa;
    }

    public void CrearEnTodosLosPuntos()
    {
        for (int i = 0; i < puntosDeSpawn.Length; i++)
        {
            CrearBolsa(puntosDeSpawn[i].position);
            puntosDeSpawn[i].gameObject.SetActive(false);
        }
    }
}