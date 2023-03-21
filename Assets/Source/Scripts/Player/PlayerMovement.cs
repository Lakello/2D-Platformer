using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : Player
{
    [SerializeField, Range(1, 500)] private float _moveSpeed = 365;

    public event UnityAction OnMoveing;

    private void FixedUpdate()
    {
        Move(KeyboardInput.Horizontal);
    }

    private void Move(float horizontalInput)
    {
        OnMoveing?.Invoke();

        float newVelocity = horizontalInput * _moveSpeed * Time.deltaTime;

        SelfRigidbody2D.velocity = new Vector2(newVelocity, SelfRigidbody2D.velocity.y);
    }
}