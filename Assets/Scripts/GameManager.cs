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
    public int currentLevel;
    public LevelUp uiLevelUp;
    public LoadScene loadScene;

    [Header("# Game Control")]
    public float gameTime;
    public float maxGameTime = 2*10f;
    [Header("# Player Info")]
    public bool isLive;
    public bool ganar;
    public float health;
    public float maxHealth = 100;
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 3, 5, 10, 100, 150, 210, 280, 360, 450, 650 };

    public EnemyData enemyData;

    public AudioClip audioClipHit;
    public AudioClip audioClipDead;
    public AudioSource audioSource;

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
        health = maxHealth;

        audioSource = GetComponent<AudioSource>();
        //audioClipHit = Resources.Load<AudioClip>("Undead Survivor/Audio/Hit0");
        //audioClipDead = Resources.Load<AudioClip>("Undead Survivor/Audio/Dead");
    }
    void Start()
    {
        StartCoroutine(InitializeAfterPlayer());
    }

    void Update()
    {
        if (!isLive) return;
        
        gameTime += Time.deltaTime;
        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
            loadScene.Derrota();
        }
        if (health <= 0)
        {
            loadScene.Derrota();
        }
        if (ganar)
        {
            StartCoroutine(Ganando());
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

    public void PlayHit()
    {
        audioSource.PlayOneShot(audioClipHit);
    }

    public void PlayDie()
    {
        audioSource.PlayOneShot(audioClipDead);
    }

    IEnumerator Ganando()
    {
        yield return new WaitForSeconds(0.5f);
        loadScene.Victoria();
    }
}
