using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(50, 500)] private float _force = 365;
    [SerializeField, Range(0.5f, 15f)] private float _maxSpeed = 5f;

    private Rigidbody2D _selfRigidbody;

    private void Start()
    {
        _selfRigidbody = GetComponent<Rigidbody2D>();
    }

    public void OnMoveing(float horizontalInput)
    {
        float absVelocity = Mathf.Abs(_selfRigidbody.velocity.x);

        if (absVelocity < _maxSpeed)
        {
            _selfRigidbody.AddForce(Vector2.right * horizontalInput * _force);
        }

        if (absVelocity > _maxSpeed)
        {
            _selfRigidbody.velocity = new Vector2(Mathf.Sign(_selfRigidbody.velocity.x) * _maxSpeed,
                                                    _selfRigidbody.velocity.y);
        }
    }
}
