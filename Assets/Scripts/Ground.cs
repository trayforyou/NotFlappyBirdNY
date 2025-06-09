using UnityEngine;

public class Ground : MonoBehaviour, IInteractable 
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            player.Kill();
        }
    }
}