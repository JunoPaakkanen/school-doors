using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public HealthSystem playerHealthSystem;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Apply damage to the player
            playerHealthSystem.TakeDamage(100);
        }
    }
}
