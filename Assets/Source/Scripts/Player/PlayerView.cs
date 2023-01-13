using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerView : MonoBehaviour
{
    private PlayerInput _playerInput;

    private void OnEnable()
    {
        _playerInput.
    }

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }
}
