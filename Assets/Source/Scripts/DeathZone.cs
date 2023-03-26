using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDestroyble destroyble))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
