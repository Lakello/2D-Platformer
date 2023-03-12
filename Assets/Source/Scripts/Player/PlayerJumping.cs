using System.Collections;
using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    [SerializeField, Range(1, 10)] private float _height = 3;

    private Rigidbody2D _selfRigidbody;

    private void Start()
    {
        _selfRigidbody = GetComponent<Rigidbody2D>();
    }

    public void OnJumping()
    {
        float abs = Mathf.Abs(_height * Physics2D.gravity.y);

        Vector2 force = Mathf.Sqrt(abs) * Vector2.up;

        _selfRigidbody.AddForce(force, ForceMode2D.Impulse);
    }
}
