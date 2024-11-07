using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private bool hasHealthPack = false;

    // Reference to Game Over UI
    public GameObject gameOverUI;  // Panel that will be activated when the player dies
    public GameOverUIController gameOverController;  // Reference to the GameOverUIController script

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (hasHealthPack)
        {
            hasHealthPack = false;  // Consume the health pack
            return; // Player survives one extra hit
        }

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    private void Die()
    {
        Debug.Log("Player has died. Showing Game Over screen...");
        gameOverController.ShowGameOver();

        // Show mouse cursor and unrestrict it when the game is over
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        Time.timeScale = 0f;  // Pauses the game
    }


    public void PickupHealthPack()
    {
        hasHealthPack = true;
    }

    public bool HasHealthPack()
    {
        return hasHealthPack;
    }
}
