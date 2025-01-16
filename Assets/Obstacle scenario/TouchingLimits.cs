using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import the TextMeshPro namespace
using UnityEngine.SceneManagement; // Import the Scene Management namespace

public class TouchingLimits : MonoBehaviour
{
    public bool isDroneInside = false; // Flag to track if the Drone is inside the area
    public GameObject canvasToShow; // Reference to the countdown Canvas
    public GameObject gameOverCanvas; // Reference to the Game Over Canvas
    public TextMeshProUGUI countdownText; // Reference to the TextMeshProUGUI component for the countdown

    private float countdownTime = 4f; // Countdown time in seconds
    private bool isCounting = false; // Flag to check if countdown is running

    void Start()
    {
       
        if (canvasToShow != null)
            canvasToShow.SetActive(false);

        if (gameOverCanvas != null)
            gameOverCanvas.SetActive(false);

        if (countdownText != null)
            countdownText.text = countdownTime.ToString("F0"); 
    }

    void Update()
    {
        if (isCounting && isDroneInside)
        {
            
            countdownTime -= Time.deltaTime;

            
            if (countdownText != null)
                countdownText.text = countdownTime.ToString("F0");

           
            if (countdownTime <= 0f)
            {
                countdownTime = 0f; // Ensure it doesn't go negative
                isCounting = false;
                Debug.Log("Countdown finished. Pausing game and displaying Game Over canvas.");
                PauseGameAndShowGameOver(); 
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Drone"))
        {
            isDroneInside = true;

            
            if (canvasToShow != null)
                canvasToShow.SetActive(true);

            
            if (countdownText != null)
            {
                countdownTime = 4f;
                isCounting = true; 
                countdownText.text = countdownTime.ToString("F0"); 
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Drone"))
        {
            isDroneInside = false;

            
            if (canvasToShow != null)
                canvasToShow.SetActive(false);

            
            isCounting = false;
            countdownTime = 0f; 
            if (countdownText != null)
                countdownText.text = countdownTime.ToString("F0"); 
        }
    }

    private void PauseGameAndShowGameOver()
    {
        Time.timeScale = 0f;
        if (canvasToShow != null)
            canvasToShow.SetActive(false);
        if (gameOverCanvas != null)
            gameOverCanvas.SetActive(true);
    }



}
