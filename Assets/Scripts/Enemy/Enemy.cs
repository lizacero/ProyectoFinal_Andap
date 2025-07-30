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

    void Update()
    {
        if (target == null) return;

        direction = (target.position - transform.position).normalized;

        Flip();
        anim.Play("Run");
    }

    void FixedUpdate()
    {
        if (target == null) return;

        rb.MovePosition(rb.position + direction * data.speed * Time.deltaTime);
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


    // PRUEBAS DANIELA //////////////////////////////////////////////////////////
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

    private void Dead()
    {
        gameObject.SetActive(false);
        GameManager.instance.AddPoints(data.pointsOnDeath);
    }
}
