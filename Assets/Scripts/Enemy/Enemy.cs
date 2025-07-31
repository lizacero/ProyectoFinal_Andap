using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public EnemyData data;
    public Transform target;
    private int currentHealth;
    private bool isLive = true;
    private Rigidbody2D rb;
    private Animator anim;
    public Transform spriteTransform;
    private Vector2 direction;

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


    void FixedUpdate()
    {
        if (!isLive) return;
        if (target == null) return;
        direction = (target.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * data.speed * Time.fixedDeltaTime);
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
        isLive = false;
        GameManager.instance.AddPoints(data.pointsOnDeath);
        Destroy(gameObject, 2f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Bullet")) return;

        currentHealth -= other.GetComponent<Bullet>().damage;
        if (currentHealth > 0)
        {
            anim.SetTrigger("Hit");
        }
        else
        {
            Die();
        }
    }

}
