using UnityEngine;

public class CharacterJumping : Character
{
    [SerializeField] private float _jumpVelocity;

    private void FixedUpdate()
    {
        if (CharacterInput.Vertical > 0 && IsGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        SelfRigidbody2D.velocity = new Vector2(SelfRigidbody2D.velocity.x, _jumpVelocity);
    }
}