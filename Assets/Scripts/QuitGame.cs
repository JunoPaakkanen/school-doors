using UnityEngine;

public class QuitGame : MonoBehaviour
{
    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Log message (helpful for testing in the Editor)
            Debug.Log("Escape key pressed - Exiting game");

            // Quit the application
            Application.Quit();

            // In the editor, stop playing mode
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}
