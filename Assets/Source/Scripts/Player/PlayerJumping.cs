using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(JumpFX))]
public class PlayerJumping : Player
{
    [SerializeField] private float _length;
    [SerializeField] private float _duration;

    private JumpFX _fx;
    private PureAnimation _playTime;

    private event UnityAction _landing;
    private event UnityAction _jumping;
    private event UnityAction _falling;

    private void OnEnable()
    {
        TryInitializedViewComponent();
        _jumping += PlayerView.OnJumping;
        _landing += PlayerView.OnLanding;
        _falling += PlayerView.OnFalling;
    }

    private void Awake()
    {
        _fx = GetComponent<JumpFX>();
        _playTime = new PureAnimation(this);
    }

    private void OnDisable()
    {
        _jumping -= PlayerView.OnJumping;
        _landing -= PlayerView.OnLanding;
        _falling -= PlayerView.OnFalling;
    }

    private void FixedUpdate()
    {
        if (KeyboardInput.Vertical > 0 && IsGrounded)
        {
            Jump(Vector3.up);
        }
    }

    private void Jump(Vector3 direction)
    {
        Vector3 target = transform.position + (direction * _length);
        Vector3 startPosition = transform.position;
        PureAnimation fxPlayTime = _fx.PlayAnimations(transform, _duration);

        _playTime.Play(_duration, (progress) =>
        {
            transform.position = Vector3.Lerp(startPosition, target, progress) +
                                              fxPlayTime.LastChanges.Position;

            return null;
        });
    }
}