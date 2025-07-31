using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerController player;
    public PoolManager pool;
    public int score = 0;
    //public Text scoreText;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        player = FindAnyObjectByType<PlayerController>();
        pool = FindAnyObjectByType<PoolManager>();
    }
    void Start()
    {
        
    }

    public void AddPoints(int amount)
    {
        score += amount;
        //scoreText.text = "Puntos: " + score;
    }
}
