using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJumping : PhysicsDisplacement
{
    private const float MaxProgress = 1;

    [SerializeField] private AnimationCurve _jumpingCurve;
    [SerializeField, Range(1, 10)] private float _height = 3;
    [SerializeField, Range(0.1f, 1f)] private float _maxJumpDelta = 0.2f;

    private float _currentProgress;
    private Coroutine _jump;

    public void OnJumping()
    {
        if (_jump == null || _currentProgress >= MaxProgress)
        {
            StopAllCoroutines();
            _jump = StartCoroutine(Jump());
        }
    }

    private IEnumerator Jump()
    {
        _currentProgress = 0;
        float targetPositionY;

        while(_currentProgress < MaxProgress)
        {
            _currentProgress = Mathf.MoveTowards(_currentProgress,
                                                MaxProgress,
                                                _maxJumpDelta);
                 
            targetPositionY = _height * _jumpingCurve.Evaluate(_currentProgress);

            OffsetTargetPosition.y = targetPositionY;

            yield return null;
        }
    }
}
