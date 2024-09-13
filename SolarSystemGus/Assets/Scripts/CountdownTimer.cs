using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining = 30f;  // Set the countdown time (e.g., 30 seconds)
    public TextMeshProUGUI timerText;  // Reference to the UI Text component for the timer
    private bool timerIsRunning = false;

    void Start()
    {
        timerIsRunning = true;  // Start the timer
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;  // Decrease the time
                UpdateTimerUI(timeRemaining);     // Update the UI
            }
            else
            {
                // Time has run out
                timeRemaining = 0;
                timerIsRunning = false;

                // Load the next level (scene)
                LoadNextScene();
            }
        }
    }

    void UpdateTimerUI(float timeToDisplay)
    {
        // Convert the time to minutes and seconds format (e.g., 00:30)
        timeToDisplay = Mathf.Max(0, timeToDisplay);  // Ensure the time doesn't go below 0
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // Update the timerText in the UI
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void LoadNextScene()
    {
        // Use SceneManager to load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
