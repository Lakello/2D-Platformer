using UnityEngine;

public class PlayerJumping : Player
{
    [SerializeField] private float _jumpVelocity;

    private void FixedUpdate()
    {
        if (KeyboardInput.Vertical > 0 && IsGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        SelfRigidbody2D.velocity = new Vector2(SelfRigidbody2D.velocity.x, _jumpVelocity);
    }
}