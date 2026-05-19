using UnityEngine;

public class PickaxeManager : MonoBehaviour
{
    private UI_Manager ui_Manager;

    private void Start()
    {
        ui_Manager = Object.FindFirstObjectByType<UI_Manager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (ui_Manager != null)
            {
                ui_Manager.Win();
            }
        }
    }
}