using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private int _coinCollected;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            coin.OnCollecting();
            _coinCollected++;
        }
    }
}
