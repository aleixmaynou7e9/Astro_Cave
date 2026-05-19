using UnityEngine;
using UnityEngine.UI;

public class DiscreteHeartHealth : MonoBehaviour
{
    [Header("Referencias de la GUI")]
    [Tooltip("Arrastra aquí las 3 imágenes dinámicas (las blancas hijas)")]
    [SerializeField] private Image[] lifeIcons;

    [Header("Configuración de Colores")]
    [SerializeField] private Color fullColor = Color.white;

    private AudioClip HurtClip;
    private UI_Manager ui_Manager;

    private int currentHealth;
    private const int MaxHealthPerIcon = 2;

    void Start()
    {
        ui_Manager = FindAnyObjectByType<UI_Manager>();

        currentHealth = lifeIcons.Length * MaxHealthPerIcon;
        UpdateVisualHealth();
    }

    public void TakeDamage()
    {
        currentHealth -= 1;
        Debug.Log("Impact detected. Actual HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            ui_Manager.Die();
        }

        UpdateVisualHealth();
    }

    private void UpdateVisualHealth()
    {
        if (lifeIcons != null && lifeIcons.Length == 3)
        {
            UpdateSingleIcon(0, 1, 2);

            UpdateSingleIcon(1, 3, 4);

            UpdateSingleIcon(2, 5, 6);
        }
    }

    private void UpdateSingleIcon(int iconIndex, int lowHealthPoint, int fullHealthPoint)
    {
        if (lifeIcons[iconIndex] != null)
        {
            if (currentHealth >= fullHealthPoint)
            {
                lifeIcons[iconIndex].fillAmount = 1.0f; // Cabeza completa blanca
                lifeIcons[iconIndex].color = fullColor;
            }
            else if (currentHealth == lowHealthPoint)
            {
                lifeIcons[iconIndex].fillAmount = 0.5f; // Mitad de cabeza
            }
            else
            {
                lifeIcons[iconIndex].fillAmount = 0.0f; // Contenedor vacío
            }
        }
    }
}