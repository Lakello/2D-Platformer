using UnityEngine;
using UnityEngine.Events;

public class Menu : MonoBehaviour
{
    [SerializeField] private KeyCode _openMenuKey;

    [SerializeField] private UnityEvent _pause;
    [SerializeField] private UnityEvent _play;

    private bool _isPaused;

    private void Update()
    {
        if (Input.GetKeyDown(_openMenuKey))
        {
            _isPaused = !_isPaused;

            Pause(_isPaused);
        }
    }

    private void Pause(bool active)
    {
        if (active)
        {
            _pause.Invoke();
        }
        else
        {
            _play.Invoke();
        }
    }
} 
