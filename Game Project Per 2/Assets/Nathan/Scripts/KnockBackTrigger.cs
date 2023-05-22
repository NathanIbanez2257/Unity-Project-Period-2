using UnityEngine;

public class KnockBackTrigger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        KnockBack(collision);
    }

    public void KnockBack(Collision2D collision)
    {
        var player = collision.collider.GetComponent<MoveScript>();
        if (player != null)
        {
            player.KnockBack(transform);

        }
    }
}
