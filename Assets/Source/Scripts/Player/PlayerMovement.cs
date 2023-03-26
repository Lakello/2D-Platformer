using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : Player
{
    [SerializeField, Range(1, 500)] private float _moveSpeed = 365;

    private event UnityAction<float> _moveing;

    private void FixedUpdate()
    {
        Move(KeyboardInput.Horizontal);
    }

    protected override void Subscribe()
    {
        _moveing += PlayerView.OnMoveing;
    }

    protected override void Unsubscribe()
    {
        _moveing -= PlayerView.OnMoveing;
    }

    private void Move(float horizontalInput)
    {
        _moveing?.Invoke(horizontalInput);

        float newVelocity = horizontalInput * _moveSpeed * Time.deltaTime;

        SelfRigidbody2D.velocity = new Vector2(newVelocity, SelfRigidbody2D.velocity.y);
    }
}