using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public RubikTimer rubikTimer; // Reference to the RubikTimer
    public HistoryManager historyManager; // Reference to the HistoryManager
    private int currentRound = 1; // Track the current round

    public void OnSolveButtonClicked()
    {
        rubikTimer.StopTimer(); // Stop the timer
        float elapsedTime = rubikTimer.GetElapsedTime(); // Get the elapsed time
        historyManager.AddHistoryEntry(currentRound, elapsedTime); // Add to history
        currentRound++; // Increment the round for the next game
    }
}
