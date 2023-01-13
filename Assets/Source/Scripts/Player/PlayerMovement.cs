using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float _jumpForce = 100f;
	[SerializeField] private float _movementSpeed = 50f;
	[Range(0, .3f)] [SerializeField] private float _moveSmoothTime = .05f;

	private GroundChecker _groundChecker = new();
	private Rigidbody2D _selfRigidbody2D;
	private Collider2D _selfCollider2D;
	private PlayerInput _playerInput;
	private Vector2 _velocity;

	private bool IsGrounded => _groundChecker.Check(_selfCollider2D);

    private void OnEnable()
    {
		_playerInput.Jumping += OnJumping;
		_playerInput.Slideing += OnSlideing;
		_playerInput.Moveing += OnMoveing;
    }

    private void Start()
	{
		_selfRigidbody2D = GetComponent<Rigidbody2D>();
		_selfCollider2D = GetComponent<Collider2D>();
		_playerInput= GetComponent<PlayerInput>();
	}

    private void OnDisable()
    {
        _playerInput.Jumping -= OnJumping;
        _playerInput.Slideing -= OnSlideing;
        _playerInput.Moveing -= OnMoveing;
    }

    private void OnMoveing(float move)
	{
		move = move * _movementSpeed * Time.deltaTime;

        Vector2 targetVelocity = new Vector2(move, _selfRigidbody2D.velocity.y);
        _selfRigidbody2D.velocity = Vector2.SmoothDamp(_selfRigidbody2D.velocity,
                                                       targetVelocity,
                                                       ref _velocity,
                                                       _moveSmoothTime);
    }

    private void OnSlideing()
	{

	}

    private void OnJumping()
	{
        if (IsGrounded)
        {
            _selfRigidbody2D.velocity = new Vector2(_selfRigidbody2D.velocity.x, _jumpForce);
        }
    }
}