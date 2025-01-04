using UnityEngine;

public class ShuffleManager : MonoBehaviour
{
    public RubikTimer rubikTimer; // Reference to RubikTimer script
    public float delayAfterShuffle = 8.0f; // Delay time in seconds before starting the timer

    public void Shuffle()
    {
        // Call PerformShuffle and schedule the timer to start after a delay
        PerformShuffle();
        Invoke(nameof(StartTimerAfterShuffle), delayAfterShuffle);
    }

    private void PerformShuffle()
    {
        // Implement the Rubik shuffle logic here
        Debug.Log("Rubik has been shuffled");
    }

    private void StartTimerAfterShuffle()
    {
        // Start the timer after the shuffle delay
        if (rubikTimer != null)
        {
            rubikTimer.StartTimer();
            Debug.Log("Timer started after shuffle.");
        }
        else
        {
            Debug.LogError("RubikTimer reference is not assigned.");
        }
    }
}
