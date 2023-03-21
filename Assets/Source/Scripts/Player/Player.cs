using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(KeyboardInput))]
[RequireComponent(typeof(PlayerView))]
public class Player : MonoBehaviour
{
    protected Rigidbody2D SelfRigidbody2D;
    protected KeyboardInput KeyboardInput;
    protected PlayerView PlayerView;

    private Collider2D _selfCollider2D;
    private GroundChecker _groundChecker = new();

    protected bool IsGrounded => _groundChecker.Check(_selfCollider2D);

    private void Start()
    {
        SelfRigidbody2D = GetComponent<Rigidbody2D>();
        _selfCollider2D = GetComponent<Collider2D>();
        KeyboardInput = GetComponent<KeyboardInput>();
    }

    protected void TryInitializedViewComponent()
    {
        if (PlayerView == null)
        {
            PlayerView = GetComponent<PlayerView>();
        }
    }
}