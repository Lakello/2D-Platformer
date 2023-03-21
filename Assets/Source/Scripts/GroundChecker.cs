using UnityEngine;

public class GroundChecker
{
    public bool Check(Collider2D collider2D)
    {
        Collider2D[] colliders = new Collider2D[8];

        colliders = Physics2D.OverlapCapsuleAll(collider2D.bounds.center,
                                                       collider2D.bounds.size,
                                                       CapsuleDirection2D.Vertical,
                                                       collider2D.gameObject.transform.rotation.x);


        return TryFindLevelComponent(colliders);
    }

    private bool TryFindLevelComponent(Collider2D[] colliders)
    {
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out Ground level))
            {
                return true;
            }
        }

        return false;
    }
}
