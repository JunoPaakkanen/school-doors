using UnityEngine;

public class DestroyItem : MonoBehaviour
{
    // You can specify the tag of the player, for example, "Player"
    public string targetTag = "Player";
    public HealthSystem playerHealthSystem;


    private void Start()
    {
        if (playerHealthSystem == null)
        {
            playerHealthSystem = GameObject.FindWithTag(targetTag)?.GetComponent<HealthSystem>();
            if (playerHealthSystem == null)
                Debug.LogError("HealthSystem component not found on Player.");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided with the health pack has the "Player" tag
        if (other.CompareTag(targetTag))
        {
            playerHealthSystem.PickupHealthPack();  // Pick up healthpack
            Destroy(gameObject);  // Destroys the health pack object
        }
    }
}
