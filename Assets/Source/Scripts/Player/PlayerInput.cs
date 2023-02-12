using UnityEngine;

public class PlayerInput : MonoBehaviour 
{
	public float Horizontal 
	{ 
		get 
		{ 
			return Input.GetAxisRaw(Axis.Horizontal);
		}
	}
	public float Vertical 
	{
		get
		{
			return Input.GetAxisRaw(Axis.Vertical);
		}
	}
}