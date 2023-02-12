using UnityEngine;

[RequireComponent(typeof(PlayerPossitilities), typeof(Animator), typeof(SpriteRenderer))]
public class PlayerView : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Animator _selfAnimator;
    private SpriteRenderer _selfSpriteRenderer;
    private bool _isRun;
    private bool _leftDirection;

    private void OnValidate()
    {
        if (_player == null)
        {
            Debug.LogError($"{nameof(PlayerView)} => Component <<{nameof(Player)}>> = null");
        }
    }

    private void OnEnable()
    {
        _player.Grounding += OnGrounding;
        _player.Moveing += OnMoveing;
        _player.Jumping += OnJumping;
        _player.Falling += OnFalling;
        _player.Shooting += OnShooting;
    }

    private void Start()
    {
        _selfAnimator = GetComponent<Animator>();
        _selfSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnDisable()
    {
        _player.Grounding -= OnGrounding;
        _player.Moveing -= OnMoveing;
        _player.Jumping -= OnJumping;
        _player.Falling -= OnFalling;
        _player.Shooting -= OnShooting;
    }

    private void OnGrounding(bool value)
    {
        SetAnimatorParameter(PlayerAnimatorController.Parameters.IsGrounded, value);
    }

    private void OnMoveing(float horizontalInput)
    {
        SetDirection(horizontalInput);
        TryFlipView();

        if (horizontalInput == 0 && _isRun)
        {
            _isRun = false;
        }
        else if ((horizontalInput == 0) == false && _isRun == false)
        {
            _isRun = true;
        }

        SetAnimatorParameter(PlayerAnimatorController.Parameters.IsRun, _isRun);
    }

    private void SetDirection(float horizontalInput)
    {
        if (horizontalInput > 0)
        {
            _leftDirection = false;
        }
        else if (horizontalInput < 0)
        {
            _leftDirection = true;
        }
    }

    private void TryFlipView()
    {
        if (_isRun)
        {
            _selfSpriteRenderer.flipX = _leftDirection;
        }
    }

    private void OnJumping()
    {
        SetAnimatorParameter(PlayerAnimatorController.Parameters.IsJump);

    }

    private void OnFalling()
    {
        SetAnimatorParameter(PlayerAnimatorController.Parameters.IsFall);

    }

    private void OnShooting()
    {
        SetAnimatorParameter(PlayerAnimatorController.Parameters.IsShoot);

    }

    private void SetAnimatorParameter(string parameterName)
    {
        _selfAnimator.SetTrigger(parameterName);
    }

    private void SetAnimatorParameter(string parameterName, bool value)
    {
        _selfAnimator.SetBool(parameterName, value);
    }
}
