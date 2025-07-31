using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefab;
    //public EnemyData[] enemiesByLevel;
    public float spawnRate = 5f;
    private float timer;
    public int currentLevel = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnEnemy();
            timer = 0f;

            
            if (spawnRate > 1f)
                spawnRate -= 0.05f;
        }
    }

    void SpawnEnemy()
    {
        int level = GameManager.instance.currentLevel;
        int enemyCount = Mathf.Min(currentLevel + 2, enemyPrefab.Length);
        //int index = Random.Range(0, enemyCount);

        Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];
        int randomPrefabIndex = Random.Range(0, enemyPrefab.Length);
        GameObject enemy = Instantiate(enemyPrefab[randomPrefabIndex], point.position, Quaternion.identity);

        Enemy enemyScript = enemy.GetComponent<Enemy>();
        //enemyScript.data = enemyPrefab[index].GetComponent<Enemy>().data;
    }
}