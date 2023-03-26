using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(CharacterView))]
[RequireComponent(typeof(IInputeble))]
public class Character : MonoBehaviour, IDestroyble
{
    [SerializeField] protected IInputeble CharacterInput;
    protected Rigidbody2D SelfRigidbody2D;
    protected CharacterView PlayerView;

    private Collider2D _selfCollider2D;
    private GroundChecker _groundChecker = new();

    protected bool IsGrounded => _groundChecker.Check(_selfCollider2D);

    private void OnEnable()
    {
        TryInitializedViewComponent();
        Subscribe();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    private void Start()
    {
        SelfRigidbody2D = GetComponent<Rigidbody2D>();
        _selfCollider2D = GetComponent<Collider2D>();
        CharacterInput = GetComponent<IInputeble>();
    }

    protected void TryInitializedViewComponent()
    {
        if (PlayerView == null)
        {
            PlayerView = GetComponent<CharacterView>();
        }
    }

    protected virtual void Subscribe() { }

    protected virtual void Unsubscribe() { }
}