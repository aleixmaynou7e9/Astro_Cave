using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class LinearPatrolMovement : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    [SerializeField] private float speed = 2f;
    
    [Header("Configuración de Dirección")]
    [Tooltip("True para movimiento Vertical (Y), False para movimiento Horizontal (X)")]
    [SerializeField] private bool isVertical = true;

    private Rigidbody2D rb;
    private int direction = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic; 
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void FixedUpdate()
    {
        if (isVertical)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, speed * direction);
        }
        else
        {
            rb.linearVelocity = new Vector2(speed * direction, rb.linearVelocity.y);
        }
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
        Debug.Log($"[{gameObject.name}] ¡Punto de patrulla alcanzado! Nueva dirección: {direction}");
    }
}