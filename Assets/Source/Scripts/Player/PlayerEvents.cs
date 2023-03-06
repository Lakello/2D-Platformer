using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(KeyboardInput))]
[RequireComponent(typeof(PlayerView))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerJumping))]
public class PlayerEvents : MonoBehaviour
{
    private Rigidbody2D _selfRigidbody2D;
    private Collider2D _selfCollider2D;
    private KeyboardInput _keyboardInput;
    private PlayerView _playerView;
    private PlayerMovement _playerMovement;
    private PlayerJumping _playerJumping;
    private GroundChecker _groundChecker = new();
    private bool _isInitialized;

    private bool IsGrounded => _groundChecker.Check(_selfCollider2D);

    public event Action<float> Moveing;
    public event Action<bool> Grounding;
    public event Action Jumping;
    public event Action Falling;
    public event Action Shooting;

    private void OnEnable()
    {
        if (_isInitialized) Subscribe();
    }

    private void Start()
    {
        _selfRigidbody2D = GetComponent<Rigidbody2D>();
        _selfCollider2D = GetComponent<Collider2D>();
        _keyboardInput = GetComponent<KeyboardInput>();
        _playerView = GetComponent<PlayerView>();
        _playerJumping = GetComponent<PlayerJumping>();
        _playerMovement = GetComponent<PlayerMovement>();

        _isInitialized = true;
        Subscribe();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    private void Update()
    {
        TryCallGrounding();
        TryCallFalling();
        TryCallJumping();
        TryCallMoveing();
        TryCallShooting();
    }

    private void Subscribe()
    {
        Moveing += _playerView.OnMoveing;
        Moveing += _playerMovement.OnMoveing;

        Jumping += _playerView.OnJumping;
        Jumping += _playerJumping.OnJumping;

        Grounding += _playerView.OnGrounding;

        Falling += _playerView.OnFalling;

        Shooting += _playerView.OnShooting;
    }

    private void Unsubscribe()
    {
        Moveing -= _playerView.OnMoveing;
        Moveing -= _playerMovement.OnMoveing;

        Jumping -= _playerView.OnJumping;
        Jumping -= _playerJumping.OnJumping;

        Grounding -= _playerView.OnGrounding;

        Falling -= _playerView.OnFalling;

        Shooting -= _playerView.OnShooting;
    }

    private void TryCallGrounding()
    {
        Grounding?.DynamicInvoke(IsGrounded);
    }

    private void TryCallMoveing()
    {
        if ((_keyboardInput.Horizontal == 0) == false)
        {
            Moveing?.DynamicInvoke(_keyboardInput.Horizontal);
        }
    }

    private void TryCallJumping()
    {
        if (_keyboardInput.Vertical > 0 && IsGrounded)
        {
            Jumping?.Invoke();
        }
    }

    private void TryCallFalling()
    {
        if (_selfRigidbody2D.velocity.y < 0 && (IsGrounded == false))
        {
            Falling?.Invoke();
        }
    }

    private void TryCallShooting()
    {

    }
}