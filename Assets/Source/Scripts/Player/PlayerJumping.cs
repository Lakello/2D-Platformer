using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJumping : MonoBehaviour
{
    private const float MaxProgress = 1;

    [SerializeField] private AnimationCurve _jumpingCurve;
    [SerializeField, Range(1, 10)] private float _height = 3;
    [SerializeField, Range(0.1f, 1f)] private float _maxJumpDelta = 0.2f;

    private float _currentProgress;
    private Coroutine _jump;
    private Rigidbody2D _selfRigidbody2D;

    private void Start()
    {
        _selfRigidbody2D = GetComponent<Rigidbody2D>();
    }

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
        float yPosition;

        while(_currentProgress < MaxProgress)
        {
            _currentProgress = Mathf.MoveTowards(_currentProgress,
                                                MaxProgress,
                                                _maxJumpDelta);
                 
            yPosition = _height * _jumpingCurve.Evaluate(_currentProgress);

            Vector2 targetPosition = new Vector2(_selfRigidbody2D.position.x,
                                                yPosition + _selfRigidbody2D.position.y);

            _selfRigidbody2D.MovePosition(targetPosition);

            yield return null;
        }
    }
}
