using UnityEngine;

public class DestroyItem : MonoBehaviour
{
    // You can specify the tag of the player, for example, "Player"
    public string targetTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided with the health pack has the "Player" tag
        if (other.CompareTag(targetTag))
        {
            Destroy(gameObject);  // Destroys the health pack object
        }
    }
}
