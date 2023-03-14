using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(1, 500)] private float _force = 365;

    private Rigidbody2D _selfRigidbody;

    private void Start()
    {
        _selfRigidbody = GetComponent<Rigidbody2D>();
    }

    public void OnMoveing(float horizontalInput)
    {
        _selfRigidbody.velocity = new Vector2(horizontalInput * _force * Time.deltaTime,
                                                _selfRigidbody.velocity.y);
    }
}