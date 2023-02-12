using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    protected Rigidbody2D _selfRigidbody2D;
    protected Collider2D _selfCollider2D;

    private PlayerInput _playerInput;
    private GroundChecker _groundChecker = new();

    public event Action<float> Moveing;
    public event Action<bool> Grounding;
    public event Action Jumping;
    public event Action Falling;
    public event Action Shooting;

    protected bool IsGrounded => _groundChecker.Check(_selfCollider2D);

    private void Start()
    {
        _selfRigidbody2D = GetComponent<Rigidbody2D>();
        _selfCollider2D = GetComponent<Collider2D>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        TryCallGrounding();
        TryCallFalling();
        TryCallJumping();
        TryCallMoveing();
        TryCallShooting();
    }

    private void TryCallGrounding()
    {
        Grounding?.DynamicInvoke(IsGrounded);
    }

    private void TryCallMoveing()
    {
        if (IsGrounded) Moveing?.DynamicInvoke(_playerInput.Horizontal);
    }

    private void TryCallJumping() 
    {
        if (_playerInput.Vertical > 0 && IsGrounded)
        {
            Jumping?.Invoke();
        }
    }

    private void TryCallFalling()
    {
        if (_selfRigidbody2D.velocity.y < 0)
        {
            Falling?.Invoke();
        }
    }

    private void TryCallShooting()
    {

    }
}
