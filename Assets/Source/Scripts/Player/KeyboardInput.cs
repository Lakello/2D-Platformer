using UnityEngine;

public class KeyboardInput : MonoBehaviour, IInputeble
{
    public float Horizontal => Input.GetAxisRaw(Axis.Horizontal);

    public float Vertical => Input.GetAxisRaw(Axis.Vertical);
}