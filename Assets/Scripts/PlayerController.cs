using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 inputVector;
    public float speed = 3f;
    public Scanner scanner;
    public Hand[] hands;
    public LoadScene loadScene;
    
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
        hands = GetComponentsInChildren<Hand>(true);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //inputVector.x = Input.GetAxisRaw("Horizontal");
        //inputVector.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        if (!GameManager.instance.isLive) return;
        Vector2 nextVector = inputVector.normalized * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + nextVector);
    }

    private void OnMove(InputValue value)
    {
        if (!GameManager.instance.isLive) return;
        inputVector = value.Get<Vector2>();
        if (inputVector.x > 0)
        {
            sprite.flipX = false;
        }
        else if (inputVector.x < 0)
        {
            sprite.flipX = true;
        }
        animator.SetFloat("Speed", inputVector.magnitude);
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameManager.instance.health -= Time.deltaTime * other.gameObject.GetComponent<Enemy>().data.damage;
        }
        if (GameManager.instance.health <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {

        for (int i=3; i<transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        animator.SetTrigger("Dead");
        GetComponent<Collider2D>().enabled = false;
        rb.linearVelocity = Vector2.zero;
    }
}
