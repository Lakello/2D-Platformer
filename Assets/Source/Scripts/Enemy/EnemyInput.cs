using System.Collections;
using UnityEngine;

public class EnemyInput : Enemy, IInputeble
{
    [SerializeField] private float _timeOutPoint = 1f;
    private bool _isTimeOut;
    private int _direction = 1;
    private float _horizontal;
    private float _vertical;

    public float Horizontal => _horizontal;

    public float Vertical => _vertical;

    private void Start()
    {
        StartCoroutine(UpdateHorizontal());
    }

    protected override void OnExtremePointEnter()
    {
        _isTimeOut = true;
        ReverseDirection();
    }

    private IEnumerator UpdateHorizontal()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_timeOutPoint);

        while (gameObject.activeSelf == true)
        {
            _horizontal = _direction;

            if (_isTimeOut)
            {
                _horizontal = 0;
                yield return waitForSeconds;
                _isTimeOut = false;
            }
            else
            {
                yield return null;
            }
        }
    }

    private void ReverseDirection()
    {
        _direction = -_direction;
    }
}
