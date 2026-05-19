using UnityEngine;

public class JumpTriggerController : MonoBehaviour
{
    PlayerController playerController;

    private void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            playerController.PlayerJump(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            playerController.PlayerJump(false);
        }
    }
}
