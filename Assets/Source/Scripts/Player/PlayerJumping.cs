using System.Collections;
using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    [SerializeField, Range(1f, 10f)] private float _height = 3f;
    [SerializeField, Range(0.1f, 10f)] private float _timeToReachHeight = 1f;

    private Rigidbody2D _selfRigidbody;
    private float _startPositionY;

    private float _endPositionY => _startPositionY + _height;

    private void Start()
    {
        _selfRigidbody = GetComponent<Rigidbody2D>();
    }

    public void OnJumping()
    {
        StopAllCoroutines();

        StartCoroutine(Jump());
    }

    private IEnumerator Jump()
    {
        _startPositionY = _selfRigidbody.position.y;

        while (_selfRigidbody.position.y <= _endPositionY)
        {
            float targetVelocity = Mathf.Lerp(_startPositionY,
                                                _endPositionY,
                                                _timeToReachHeight);

            SetVelocity(targetVelocity);

            yield return null;
        }

        SetVelocity(0);
    }

    private void SetVelocity(float value)
    {
        _selfRigidbody.velocity = new Vector2(_selfRigidbody.velocity.x, value);
    }
}