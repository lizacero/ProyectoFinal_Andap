using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyData[] enemyTypes;
    public GameObject enemyPrefab;
    public float spawnInterval = 5f;
    public Transform[] spawnPoints;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 2f, spawnInterval);
    }

    void SpawnEnemy()
    {
        Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];
        EnemyData data = enemyTypes[Random.Range(0, enemyTypes.Length)];

        GameObject newEnemy = Instantiate(enemyPrefab, point.position, Quaternion.identity);
        Enemy enemyScript = newEnemy.GetComponent<Enemy>();
        enemyScript.data = data;
    }
}
