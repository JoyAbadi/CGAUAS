using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HistoryManager : MonoBehaviour
{
    public TMP_Text historyManagerText; // Reference to the UI Text for displaying history
    private List<string> historyEntries = new List<string>();

    // Method to add a new entry to the history
    public void AddHistoryEntry(int round, float time)
    {
        string entry = $"Round {round}: {FormatTime(time)}";
        historyEntries.Add(entry);
        UpdateHistoryDisplay();
    }

    // Update the history display
    private void UpdateHistoryDisplay()
    {
        if (historyManagerText != null) // Check if historyManagerText is assigned
        {
            historyManagerText.text = string.Join("\n", historyEntries);
        }
        else
        {
            Debug.LogError("HistoryManagerText is not assigned in HistoryManager.");
        }
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
