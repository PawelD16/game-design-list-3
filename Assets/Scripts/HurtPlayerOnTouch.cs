using UnityEngine;

public class HurtPlayerOnTouch : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Hurt player!");

        if (collision.CompareTag(PlayerManager.PLAYER_TAG))
            PlayerManager.DecrementPlayerHealth();
    }
}
