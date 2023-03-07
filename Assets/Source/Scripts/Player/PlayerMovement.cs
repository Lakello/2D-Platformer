using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : PhysicsDisplacement
{
    [SerializeField, Range(0.5f, 15f)] private float _movementSpeed = 10f;

    public void OnMoveing(float horizontalInput)
    {
        float targetPositionX = (horizontalInput * _movementSpeed * Time.deltaTime);

        OffsetTargetPosition.x = targetPositionX;
    }
}
