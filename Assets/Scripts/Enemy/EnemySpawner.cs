using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefab;

    public int currentLevel;
    public int nextLevel;

    public float spawnRate = 5f; // SpawnRate inicial
    public float spawnRateDecrease = 0.3f; // Cuánto disminuye por nivel
    public float minSpawnRate = 0.5f; // SpawnRate mínimo
    
    private float timer;

    void Start()
    {
        nextLevel = 2;
        
    }

    void Update()
    {
        if (!GameManager.instance.isLive) return;
        currentLevel = GameManager.instance.level;
        // Calcular spawnRate basado en el nivel
        if (currentLevel == nextLevel)
        {
            spawnRate = Mathf.Max(minSpawnRate, spawnRate - spawnRateDecrease);
            nextLevel++;
        }
        
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    //void Update()
    //{
        //if (!GameManager.instance.isLive) return;
        //timer += Time.deltaTime;

        //if (timer >= spawnRate)
        //{
            //SpawnEnemy();
            //timer = 0f;

            
            //if (spawnRate > 1f)
            //spawnRate -= 0.05f;
        //}
    //}

    void SpawnEnemy()
    {
        
        int enemyCount = Mathf.Min(currentLevel + 2, enemyPrefab.Length);
        //int index = Random.Range(0, enemyCount);

        Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];
        int randomPrefabIndex = Random.Range(0, enemyPrefab.Length);
        GameObject enemy = Instantiate(enemyPrefab[randomPrefabIndex], point.position, Quaternion.identity);

        Enemy enemyScript = enemy.GetComponent<Enemy>();
        //enemyScript.data = enemyPrefab[index].GetComponent<Enemy>().data;
    }
}