using System.Collections;
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
    public LevelUp uiLevelUp;

    [Header("# Game Control")]
    public float gameTime;
    public float maxGameTime = 2*10f;
    [Header("# Player Info")]
    public bool isLive = true;
    public int health;
    public int maxHealth = 100;
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 3, 5, 10, 100, 150, 210, 280, 360, 450, 650 };


    private void Awake()
    {
        isLive = true;
        if (instance == null) instance = this;
        else Destroy(gameObject);

        if (player == null)
        {
            player = FindAnyObjectByType<PlayerController>();
        }
        if (pool == null)
        {
            pool = FindAnyObjectByType<PoolManager>();
        }
    }
    void Start()
    {
        health = maxHealth;

        StartCoroutine(InitializeAfterPlayer());
    }

    void Update()
    {
        if (!isLive) return;

        gameTime += Time.deltaTime;
        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }

    public void GetExp()
    {
        exp++;
        if (exp == nextExp[Mathf.Min(level, nextExp.Length - 1)])
        {
            level++;
            exp = 0;
            uiLevelUp.Show();
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

    IEnumerator InitializeAfterPlayer()
    {
        yield return new WaitForEndOfFrame();
        uiLevelUp.Select(0);
    }

    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0;
    }
    public void Resume()
    {
        isLive = true;
        Time.timeScale = 1;
    }

}
