using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy/EnemyData")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public float speed;
    public float maxHealth;
    public float damage;
    public int pointsOnDeath;
    public Sprite sprite;
}
