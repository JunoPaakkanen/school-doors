using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    // Track if player has health pack
    private bool hasHealthPack = false;

    public delegate void HealthChanged(int currentHealth, int maxHealth);
    public event HealthChanged OnHealthChanged;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        // If the player has a health pack, use it to survive an extra hit
        if (hasHealthPack)
        {
            hasHealthPack = false;  // Consume the health pack
            Debug.Log("Health Pack used! You can take one more hit.");
            return; // Don't decrease health here, player survives one extra hit
        }

        // If no health pack, take damage as normal
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }

        // Trigger health changed event
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        // Trigger health changed event
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    // Player dies
    private void Die()
    {
        Debug.Log("Player has died.");
        // You can disable the object, play a death animation, or trigger a Game Over screen here.
        gameObject.SetActive(false);
    }

    // Method to pick up a health pack
    public void PickupHealthPack()
    {
        hasHealthPack = true;
        Debug.Log("Health Pack acquired!");
    }

    // Check if the player has a health pack
    public bool HasHealthPack()
    {
        return hasHealthPack;
    }
}
