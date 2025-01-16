using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

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

    private bool timerStarted = false;
    private float timeLimit = 180.1f;
    private bool gamePaused = false;
    private bool csvSaved = false;
    private List<string> csvRows = new List<string>(); // List to store CSV rows

    private void Start()
    {
        count_time = 0;
        gameCompletePanel.SetActive(false);

        // Add CSV header row
        csvRows.Add("Time,Height,Speed,Score");
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
                if (Setting.Attitude)
                {
                    GPS.text = "(ATTI Mode)";
                }
                else
                {
                    GPS.text = "(GPS Mode)";
                }

                // Gather data
                float heightValue = drone.position.y;
                float speedValue = drone.speed;
                float precisionValue = scoreManager.GetPrecision(); // Precision is a float
                csvRows.Add($"{count_time:F2},{heightValue:F1},{speedValue:F2},{precisionValue:F1}"); // Keep precision as a float with 1 decimal place

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

    private void PauseGame()
    {
        // Pause the game and show the "Game Complete" panel
        Time.timeScale = 0;
        timerStarted = false;
        gamePaused = true;
        gameCompletePanel.SetActive(true);
    }

    private void WriteToCSV()
    {
        // Define the file path to save the CSV file in the Assets folder
        string filePath = Path.Combine(Application.dataPath, "GameData.csv");

        // Log the file path to the console for debugging purposes
        Debug.Log("CSV file saved at: " + filePath);

        // Write all rows to the CSV file in the Assets folder
        File.WriteAllLines(filePath, csvRows);
        csvSaved = true; // Ensure the file is only saved once
    }

}
