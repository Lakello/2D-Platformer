using UnityEngine;

public class KeyboardInput : MonoBehaviour 
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