using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Find the PlayerMovement script attached to the player
            Movement playerMovement = other.GetComponent<Movement>();

            // Check if the player has a PlayerMovement script
            if (playerMovement != null)
            {
                // Call the respawn method from the PlayerMovement script
                playerMovement.Respawn();
            }
        }
        else
        {
            // For other objects (e.g., enemies), destroy them
            Destroy(other.gameObject);
        }
    }
}
