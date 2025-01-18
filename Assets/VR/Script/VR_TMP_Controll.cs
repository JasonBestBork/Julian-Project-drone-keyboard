using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class VR_TMP_Control : MonoBehaviour
{
    public TextMeshProUGUI hight;
    public TextMeshProUGUI time;
    public TextMeshProUGUI speed;
    public TextMeshProUGUI GPS;
    public int min;
    public int sec;
    public int fra;
    private float count_time;
    public fly drone;
    public manager manager;
    public GameObject panel_test;
    public GameObject gameCompletePanel;
    public PrecisionManager scoreManager; // Reference to the script that holds the score
    public GameObject gameOverCanvas; // Reference to the Game Over Canvas

    private bool timerStarted = false;
    private float timeLimit = 180.1f;
    private bool gamePaused = false;
    private bool csvSaved = false;
    private List<string> csvRows = new List<string>(); // List to store CSV rows


    private void Start()
    {
        count_time = 0;
        gameCompletePanel.SetActive(false);
        if (gameOverCanvas != null)
            gameOverCanvas.SetActive(false);

        // Add CSV header row
        csvRows.Add("Time,Height,Speed,Precision");
    }

    void Update()
    {
        if (panel_test.activeSelf)
        {
            if (!timerStarted)
            {
                Debug.Log("Starting timer from zero.");
                count_time = 0;
                timerStarted = true;
            }

            if (!gamePaused)
            {
                count_time += Time.deltaTime;

                min = (int)(count_time) / 60;
                sec = (int)(count_time % 60);
                fra = (int)(count_time * 100) % 100;

                // Update the time display
                time.text = min.ToString("D2") + ":" + sec.ToString("D2") + ":" + fra.ToString("D2");

                // Update the height and speed display
                hight.text = drone.position.y.ToString("f1") + "m";
                speed.text = drone.speed.ToString("f2") + "m/s";

                // Display the mode (ATTI or GPS)
                GPS.text = Setting.Attitude ? "(ATTI Mode)" : "(GPS Mode)";

                // Gather data
                float heightValue = drone.position.y;
                float speedValue = drone.speed;
                float precisionValue = scoreManager.GetPrecision(); // Precision is a float
                csvRows.Add($"{count_time:F2},{heightValue:F1},{speedValue:F2},{precisionValue:F1}");

                // Check if the time limit is reached
                if (count_time >= timeLimit)
                {
                    Debug.Log("Time limit reached! Pausing the game...");
                    PauseGame();
                }
            }
        }

        // Check for key press when the game is paused
        if (gamePaused && Input.anyKeyDown)
        {
            if (!csvSaved)
            {
                WriteToCSV();
            }

            Debug.Log("Game is closing...");
            Application.Quit(); // Close the game
        }
    }

    public void GameOverFromOutOfBounds()
    {
        // Triggered when the drone leaves the allowed area
        if (!gamePaused)
        {
            Debug.Log("Game over triggered by out-of-bounds countdown.");
            PauseGame();
        }
    }

    private void PauseGame()
    {
        // Pause the game and show the "Game Complete" or "Game Over" panel
        Time.timeScale = 0;
        timerStarted = false;
        gamePaused = true;

        if (gameCompletePanel != null && !gameCompletePanel.activeSelf)
        {
            gameCompletePanel.SetActive(true);
        }
        if (gameOverCanvas != null && !gameOverCanvas.activeSelf)
        {
            gameOverCanvas.SetActive(true);
        }
    }

    private void WriteToCSV()
    {
        // Get the current scene's name (either "Easy" or "Medium")
        string sceneName = SceneManager.GetActiveScene().name;

        // Define the directory where the files will be saved
        string directoryPath = Application.dataPath;

        // Find the next available file number
        int fileNumber = 1;
        string filePath;
        do
        {
            // Use the scene name to create the file name (e.g., "Easy_1.csv" or "Medium_1.csv")
            filePath = Path.Combine(directoryPath, $"{sceneName}_{fileNumber}.csv");
            fileNumber++;
        } while (File.Exists(filePath)); // Increment the number if the file already exists

        // Log the file path to the console for debugging
        Debug.Log($"CSV file saved at: {filePath}");

        // Write all rows to the new CSV file
        File.WriteAllLines(filePath, csvRows);

        // Mark the file as saved to prevent duplicate saves
        csvSaved = true;
    }
}
