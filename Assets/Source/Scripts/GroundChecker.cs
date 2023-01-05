using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool Check(Collider2D collider2D)
    {
        Collider2D collider = Physics2D.OverlapCapsule(collider2D.bounds.center, 
                                                       collider2D.bounds.size, 
                                                       CapsuleDirection2D.Vertical, 
                                                       collider2D.gameObject.transform.rotation.x);

        return collider.TryGetComponent(out Level level);
    }
}
