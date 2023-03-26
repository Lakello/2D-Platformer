using UnityEngine;
using UnityEngine.Events;

public class Point : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    public event UnityAction ExtremePointEnter;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            if (enemy == _enemy)
            {
                ExtremePointEnter?.Invoke();
            }
        }
    }
}
