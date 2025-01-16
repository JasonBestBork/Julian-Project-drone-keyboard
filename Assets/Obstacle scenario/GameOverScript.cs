using UnityEngine;

public class ExitOnAnyKey : MonoBehaviour
{
    void Update()
    {
        // Detect if any key is pressed
        if (Input.anyKeyDown)
        {
            Debug.Log("Any key pressed. Exiting the game...");

            // Exit the application
            Application.Quit();

            // For testing in the Unity Editor
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}