using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float velocity = 5f;
    [SerializeField] private float jumpForce = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    private float threshold = 0.1f;
    private float horizontalMovement;
    private bool touchFloor = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("isRunning", Mathf.Abs(horizontalMovement) > threshold);

        horizontalMovement = Input.GetAxisRaw("Horizontal");
        
        if (horizontalMovement < 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (horizontalMovement > 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        // Condición de Salto explícita
        if (Input.GetButtonDown("Jump") && touchFloor)
        {
            OnJump();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalMovement * velocity, rb.linearVelocity.y);
    }

    private void OnJump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        touchFloor = false;
        
        animator.SetBool("isJumping", true); 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Vector2 contactNormal = collision.GetContact(0).normal;

            if (contactNormal.y > 0.7f)
            {
                touchFloor = true;
                animator.SetBool("isJumping", false);
                Debug.Log($"[{gameObject.name}] Suelo detectado con éxito. Normal Y: {contactNormal.y}");
            }
            else
            {
                Debug.Log($"[{gameObject.name}] Impacto lateral ignorado (Pared/Obstáculo). Normal Y: {contactNormal.y}");
            }
        }
    }
    public void PlayerJump(bool canJump)
    {
        touchFloor = canJump;
        animator.SetBool("isJumping", !touchFloor);
    }
}