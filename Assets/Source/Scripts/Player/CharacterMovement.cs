using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
	[SerializeField] private float _jumpForce = 400f;
	[Range(0, .3f)] [SerializeField] private float _moveSmoothTime = .05f;

	private bool _grounded = true;
	private Rigidbody2D _selfRigidbody2D;
	private Vector2 _velocity = Vector2.zero;

	private void Start()
	{
		_selfRigidbody2D = GetComponent<Rigidbody2D>();
	}

	public void Move(float move)
	{
        Vector2 targetVelocity = new Vector2(move, _selfRigidbody2D.velocity.y);
        _selfRigidbody2D.velocity = Vector2.SmoothDamp(_selfRigidbody2D.velocity,
                                                       targetVelocity,
                                                       ref _velocity,
                                                       _moveSmoothTime);
    }

	public void Slide()
	{

	}

	public void Jump()
	{
        if (_grounded)
        {
            _grounded = false;
            _selfRigidbody2D.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Force);
        }
    }
}