using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("1. ¡EL ENEMIGO DETECTA IMPACTO CON EL JUGADOR!");
            PlayerHealth player = collision.GetComponent<PlayerHealth>();
            
            if (player != null)
            {
                player.ReceiveHit();
            }
            else
            {
                Debug.LogError("¡ALERTA! El enemigo ha tocado al Player, pero el Player no tiene el script PlayerHealth puesto.");
            }
        }
    }
}