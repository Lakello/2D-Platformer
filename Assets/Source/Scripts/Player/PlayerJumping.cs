using UnityEngine;
using System;
using UnityEngine.Events;
using System.Collections;

public class PlayerJumping : Player
{
    [SerializeField, Range(1f, 10f)] private float _jumpVelocity = 3f;

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
            StopAllCoroutines();
            StartCoroutine(Jump());
        }
    }

    private IEnumerator Jump()
    {
        _jumping?.Invoke();

        SelfRigidbody2D.velocity = new Vector2(SelfRigidbody2D.velocity.x, _jumpVelocity);
        yield return IsGrounded == false;
        yield return SelfRigidbody2D.velocity.y > 0;

        _falling?.Invoke();

        yield return IsGrounded == true;

        _landing?.Invoke();
    }
}