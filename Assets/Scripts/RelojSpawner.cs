using UnityEngine;

public class RelojSpawner : MonoBehaviour
{
    public static RelojSpawner instance;
    //public Transform[] spawnPoints;
    public float minDistance = 3f; // Distancia mínima del jugador
    public float maxDistance = 7f; // Distancia máxima del jugador
    public GameObject relojPrefab;
    public Vector2 spawnPosition;
    public float spawnTime = 3f;
    public float maxClocksOnMap = 3f;
    private float timer = 0f;
    public int clocksOnMap = 0;
    private GameObject player;
    private Vector2 playerPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        player = GameObject.FindGameObjectWithTag("Player");
        
        if (player == null)
        {
            Debug.LogError("No se encontró player con tag 'Player'");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isLive || player == null) return;
        playerPos = player.transform.position;
        timer += Time.deltaTime;
        if (timer >= spawnTime && clocksOnMap < maxClocksOnMap)
        {
            SpawnClock();
            timer = 0f;
        }
    }

    void SpawnClock()
    {

        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        float randomDistance = Random.Range(minDistance, maxDistance);
        Vector2 spawnPos = playerPos + new Vector2(randomDirection.x, randomDirection.y) * randomDistance;
        //int randomIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(relojPrefab, spawnPos, Quaternion.identity);
        clocksOnMap++;
    }
}
