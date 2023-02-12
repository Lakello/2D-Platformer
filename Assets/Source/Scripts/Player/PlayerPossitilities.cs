using UnityEngine;

public class PlayerPossitilities : Player
{
    [SerializeField] private float _jumpForce = 100f;
    [SerializeField] private float _movementSpeed = 50f;
    [Range(0, .3f)][SerializeField] private float _moveSmoothTime = .05f;

    private void OnEnable()
    {
        Moveing += OnMoveing;
        Jumping += OnJumping;
    }

    private void OnDisable()
    {
        Moveing -= OnMoveing;
        Jumping -= OnJumping;
    }

    private void OnMoveing(float horizontalInput)
    {
        float targetVelocity = horizontalInput * _movementSpeed * Time.deltaTime;

        _selfRigidbody2D.velocity = new Vector2(targetVelocity, _selfRigidbody2D.velocity.y);
    }

    private void OnJumping()
    {
        if (IsGrounded)
        {
            _selfRigidbody2D.velocity = new Vector2(_selfRigidbody2D.velocity.x, _jumpForce);
        }
    }
}
