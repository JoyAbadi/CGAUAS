using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    // List to store the history of Rubik's cube solves
    private List<RubikHistory> rubikHistoryList = new List<RubikHistory>();

    // Method to add a solve to the history
    public void AddToHistory(string steps, float solveTime)
    {
        RubikHistory newHistory = new RubikHistory(steps, solveTime);
        rubikHistoryList.Add(newHistory);
        Debug.Log("Solve added to history: " + steps + " | Time: " + solveTime + " seconds");
    }

    // Method to retrieve the history
    public List<RubikHistory> GetHistory()
    {
        return rubikHistoryList;
    }

    // Method to display the history in the console
    public void DisplayHistory()
    {
        Debug.Log("Rubik's Cube Solve History:");
        foreach (RubikHistory history in rubikHistoryList)
        {
            Debug.Log("Steps: " + history.Steps + " | Time: " + history.SolveTime + " seconds");
        }
    }
}

// Class to represent each history entry
[System.Serializable]
public class RubikHistory
{
    public string Steps { get; private set; }
    public float SolveTime { get; private set; }

    public RubikHistory(string steps, float solveTime)
    {
        Steps = steps;
        SolveTime = solveTime;
    }
}
