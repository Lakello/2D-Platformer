using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour 
{
	public event Action<float> Moveing;
    public event Action Jumping;
    public event Action Slideing;
    public event Action Shooting;

    private void Update ()
	{
		float horizontal = Input.GetAxisRaw(Axis.Horizontal);
		float vertical = Input.GetAxisRaw(Axis.Vertical);

        if (vertical > 0)
			Jumping?.Invoke();

		if (vertical < 0)
			Slideing?.Invoke();

		Moveing?.DynamicInvoke(horizontal);
    }
}