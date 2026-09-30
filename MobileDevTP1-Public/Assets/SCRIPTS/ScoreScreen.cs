using System.Threading;
using TMPro;
using UnityEngine;

public class ScoreScreen : MonoBehaviour
{
    [SerializeField] private float currentTimer;
    [SerializeField] public GameObject canva;
    [SerializeField] public TextMeshProUGUI text;
    [SerializeField] public TextMeshProUGUI textScore;
    [SerializeField] private PlayerMovement truck;

    void Update()
    {
        currentTimer = currentTimer - Time.deltaTime;
        text.text = currentTimer.ToString();

        if (currentTimer <0)
        {
            canva.SetActive(true);
            textScore.text = ("Score:")+truck.money.ToString();
        }

    }
}
