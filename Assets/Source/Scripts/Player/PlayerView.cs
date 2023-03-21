using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class PlayerView : MonoBehaviour
{
    private Animator _selfAnimator;
    private SpriteRenderer _selfSpriteRenderer;
    private bool _isRun;
    private bool _leftDirection;

    private void Start()
    {
        _selfAnimator = GetComponent<Animator>();
        _selfSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnLanding()
    {
        SetAnimatorParameter(PlayerAnimatorController.Parameters.IsLanding);
    }

    public void OnMoveing(float horizontalInput)
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

    public void OnJumping()
    {
        SetAnimatorParameter(PlayerAnimatorController.Parameters.IsJump);

    }

    public void OnFalling()
    {
        SetAnimatorParameter(PlayerAnimatorController.Parameters.IsFall);

    }

    public void OnShooting()
    {
        SetAnimatorParameter(PlayerAnimatorController.Parameters.IsShoot);

    }

    public void SetDirection(float horizontalInput)
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

    public void TryFlipView()
    {
        if (_isRun)
        {
            _selfSpriteRenderer.flipX = _leftDirection;
        }
    }

    public void SetAnimatorParameter(string parameterName)
    {
        _selfAnimator.SetTrigger(parameterName);
    }

    public void SetAnimatorParameter(string parameterName, bool value)
    {
        _selfAnimator.SetBool(parameterName, value);
    }
}
