using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    [SerializeField] private float damageCooldown = 1.5f;

    private float nextDamageTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DiscreteHeartHealth playerHealth = Object.FindFirstObjectByType<DiscreteHeartHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage();
            }
        }
    }
    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Time.time >= nextDamageTime)
            {
                DiscreteHeartHealth playerHealth = Object.FindFirstObjectByType<DiscreteHeartHealth>();

                if (playerHealth != null)
                {
                    playerHealth.TakeDamage();
                    
                    nextDamageTime = Time.time + damageCooldown;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            nextDamageTime = 0f;
        }
    }
}