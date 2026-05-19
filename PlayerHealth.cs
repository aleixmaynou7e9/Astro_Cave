using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private DiscreteHeartHealth uiHeartHealth;

    public void ReceiveHit()
    {
        Debug.Log("2. ¡EL JUGADOR RECIBE EL IMPACTO Y LLAMA A LA UI!");
        
        if (uiHeartHealth != null)
        {
            uiHeartHealth.TakeDamage();
        }
        else
        {
            Debug.LogError("¡ALERTA! El script del jugador no tiene la UI arrastrada en el Inspector.");
        }
    }
}