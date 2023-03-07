using UnityEngine;

public class PhysicsDisplacement : MonoBehaviour
{
    protected Vector2 OffsetTargetPosition;

    private Rigidbody2D _selfRigidbody2D;

    private void Start()
    {
        _selfRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _selfRigidbody2D.MovePosition(_selfRigidbody2D.position + OffsetTargetPosition);

        ResetOffset();
    }

    private void ResetOffset()
    {
        OffsetTargetPosition = Vector2.zero;
    }
}
