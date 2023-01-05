using UnityEngine;

public class PlayerInput : MonoBehaviour {

	[SerializeField] private PlayerMovement _movement;
	[SerializeField] private float _speed = 40f;
	
	private void Update ()
	{
		float horizontal = Input.GetAxisRaw(Axis.Horizontal);
		float vertical = Input.GetAxisRaw(Axis.Vertical);

        if (vertical > 0)
			_movement.Jump();

		if (vertical < 0)
			_movement.Slide();

        _movement.Move(horizontal * _speed * Time.fixedDeltaTime);
    }
}