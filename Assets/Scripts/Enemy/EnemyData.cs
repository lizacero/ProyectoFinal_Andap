using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy/EnemyData")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public float speed;
    public int maxHealth;
    public int damage;
    public int pointsOnDeath;
    public Sprite sprite;
}
