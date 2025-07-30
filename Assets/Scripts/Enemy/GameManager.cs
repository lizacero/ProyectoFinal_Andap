using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerController player;
    public int score = 0;
    public Text scoreText;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    void Start()
    {
        // Buscar directamente el componente PlayerController en la escena
        player = FindAnyObjectByType<PlayerController>();
        if (player == null)
        {
            Debug.LogError("No se encontró ningún PlayerController en la escena");
        }
    }

    public void AddPoints(int amount)
    {
        score += amount;
        scoreText.text = "Puntos: " + score;
    }
}
