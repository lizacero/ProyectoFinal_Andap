using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("# Game Object")]
    public static GameManager instance;
    public PlayerController player;
    public PoolManager pool;
    public int score = 0;
    //public Text scoretext;
    public int currentLevel = 1;

    [Header("# Game Control")]
    public float gameTime;
    public float maxGameTime = 2*10f;
    [Header("# Player Info")]
    public int health;
    public int maxHealth = 100;
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 3, 5, 10, 100, 150, 210, 280, 360, 450, 650 };


    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        player = FindAnyObjectByType<PlayerController>();
        pool = FindAnyObjectByType<PoolManager>();
    }
    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        gameTime = Time.deltaTime;
        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }

    public void GetExp()
    {
        exp++;
        if (exp == nextExp[level])
        {
            level++;
            exp = 0;
        }
    }

    public void AddPoints(int amount)
    {
        score += amount;
        //scoreText.text = "Puntos: " + score;
    }

    public void SetLevel(int level)
    {
        currentLevel = level;
    }
}
