using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class CharacterView : MonoBehaviour
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

        SetAnimatorParameter(CharacterAnimatorController.Parameters.IsRun, _isRun);
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

    public void SetAnimatorParameter(string parameterName, bool value)
    {
        _selfAnimator.SetBool(parameterName, value);
    }
}
