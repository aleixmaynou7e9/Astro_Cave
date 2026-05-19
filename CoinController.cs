using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField]
    private AudioClip CoinClip;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (CoinClip != null)
            {
                AudioSource.PlayClipAtPoint(CoinClip, transform.position);
            }

            Destroy(gameObject);
        }
    }
}
