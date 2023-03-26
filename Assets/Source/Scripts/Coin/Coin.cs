using UnityEngine;

public class Coin : MonoBehaviour, IDestroyble
{ 
    public void OnCollecting()
    {
        gameObject.SetActive(false);
    }
}
