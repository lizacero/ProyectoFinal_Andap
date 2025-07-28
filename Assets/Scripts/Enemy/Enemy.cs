using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public EnemyData data;
    public Transform target;

    private int currentHealth;
    private Rigidbody2D rb;

    void Start()
    {
        currentHealth = data.maxHealth;
        rb = GetComponent<Rigidbody2D>();
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Jugador")?.transform;
    }

    void Update()
    {
        if (target == null) return;

        Vector2 direction = (target.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * data.speed * Time.deltaTime);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameManager.instance.AddPoints(data.pointsOnDeath);
        Destroy(gameObject);
    }
}
