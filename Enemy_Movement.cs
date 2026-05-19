using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Configuració de Moviment")]
    [SerializeField] private float velocity = 2f; 

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private int direction = 1;

    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        UpdateSpriteDirection();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(velocity * direction, rb.linearVelocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Patrol Point"))
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        direction *= -1;
    }

    private void UpdateSpriteDirection()
    {
        if (direction > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (direction < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}