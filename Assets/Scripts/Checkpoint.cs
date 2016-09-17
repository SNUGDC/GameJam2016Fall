
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private EdgeCollider2D collider;

    void Awake () {
        collider = GetComponent<EdgeCollider2D>();
    }

    public bool IsTouchingPlayer(Player player) {
        Collider2D playerCollider = player.tank.GetComponent<Collider2D>();
        return collider.IsTouching(playerCollider);
    }
}
