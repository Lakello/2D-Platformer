using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0.5f, 15f)] private float _movementSpeed = 10f;

    private Rigidbody2D _selfRigidbody2D;

    private void Start()
    {
        _selfRigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void OnMoveing(float horizontalInput)
    {
        float targetPositionX = (horizontalInput * _movementSpeed * Time.deltaTime);

        Vector2 targetPosition = new Vector2(targetPositionX + _selfRigidbody2D.position.x,
                                            _selfRigidbody2D.position.y);

        _selfRigidbody2D.MovePosition(targetPosition);
    }
}
