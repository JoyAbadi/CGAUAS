using UnityEngine;
using TMPro;

public class RubikTimer : MonoBehaviour
{
    public TMP_Text timerText; // Reference to the UI Text
    private bool isTimerRunning = false; // Is the timer running
    private float elapsedTime = 0f; // Time elapsed

    // Method to store the elapsed time
    public float GetElapsedTime()
    {
        return elapsedTime;
    }

    void Update()
    {
        // Check if the timer is running
        if (isTimerRunning)
        {
            // Add time
            elapsedTime += Time.deltaTime;

            // Format time as MM:SS:MS
            string timeFormatted = FormatTime(elapsedTime);

            // Update UI Text
            timerText.text = "Time: " + timeFormatted;
        }
    }

    // Function to start the timer
    public void StartTimer()
    {
        isTimerRunning = true;
        elapsedTime = 0f; // Reset the time
        UpdateTimerText(); // Update the UI immediately when starting
    }

    // Function to stop the timer
    public void StopTimer()
    {
        isTimerRunning = false;
    }

    // Function to reset the timer and stop it (set to 00:00:000)
    public void ResetAndStopTimer()
    {
        isTimerRunning = false;
        elapsedTime = 0f; // Reset the time to 0
        UpdateTimerText(); // Update UI to show "00:00:000"
    }

    // Update the timer text display
    private void UpdateTimerText()
    {
        timerText.text = "Time: " + FormatTime(elapsedTime); // Update UI to show current time
    }

    // Format time as "MM:SS:MS"
    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);

        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}
