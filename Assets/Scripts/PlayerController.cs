using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector2 inputVector;
    [SerializeField] private float speed = 3f;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
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
        Vector2 nextVector = inputVector.normalized * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + nextVector);
    }

    private void OnMove(InputValue value)
    {
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
}
