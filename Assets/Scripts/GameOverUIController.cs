using UnityEngine;

public class GameOverUIController : MonoBehaviour
{
    public GameObject gameOverPanel;  // Reference to the Game Over Panel

    // This function will be called when the player dies to show the Game Over UI
    public void ShowGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);  // Activate the panel
        }
    }

    // Retry the game by restarting the current scene
    public void RestartGame()
    {
        Debug.Log("Restarted");
        Time.timeScale = 1f;  // Unpauses the game
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);  // Restart the current scene

        // Hide the cursor and lock it during gameplay
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;  // Locks the cursor to the center
    }


}
