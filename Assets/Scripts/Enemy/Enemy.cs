using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public EnemyData data;
    public Transform target;

    private int currentHealth;
    private Rigidbody2D rb;

    private Animator anim;

    public Transform spriteTransform;

    private void Flip()
    {
        if (target != null && spriteTransform != null)
        {
            if (target.position.x < transform.position.x)
            {
                spriteTransform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                spriteTransform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    void Start()
    {
        currentHealth = data.maxHealth;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (target == null) return;

        Vector2 direction = (target.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * data.speed * Time.deltaTime);

        Flip();

        anim.Play("Run");
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        anim.SetTrigger("Hit");
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        anim.SetBool("Dead", true);
        GameManager.instance.AddPoints(data.pointsOnDeath);
        Destroy(gameObject, 2f);
    }
}
