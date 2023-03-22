using UnityEngine;

public class TransformChanges
{ 
    public Vector3 Position { get { return  _position; } }

    private Vector3 _position;

    public TransformChanges(Vector3 position)
    {
        _position = position;
    }
}
