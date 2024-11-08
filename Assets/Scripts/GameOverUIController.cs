using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIController : MonoBehaviour
{
    public GameObject gameOverPanel;  // Reference to the Game Over Panel
    private bool isGameOver = false;  // Tracks if the game is in a game over state

    void Update()
    {
        // If game is over and 'R' key is pressed, restart the game
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    // This function will be called when the player dies to show the Game Over UI
    public void ShowGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);  // Activate the panel
        }
        isGameOver = true;  // Set the game to game over state
        Time.timeScale = 0f;  // Optional: Pause the game when game over screen is shown
        Cursor.visible = true;  // Show the cursor for the game over menu
        Cursor.lockState = CursorLockMode.None;  // Unlock the cursor
    }

    // Retry the game by restarting the current scene
    public void RestartGame()
    {
        Debug.Log("Game Restarted");
        Time.timeScale = 1f;  // Unpauses the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Restart the current scene

        // Hide the cursor and lock it during gameplay
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;  // Locks the cursor to the center
        isGameOver = false;  // Reset game over state
    }
}
