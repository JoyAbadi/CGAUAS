using UnityEngine;
using TMPro;
using Kociemba;
using System.Collections.Generic;

public class SolveTwoPhase : MonoBehaviour
{
    public ReadCube readCube;
    public CubeState cubeState;
    private bool doOnce = true;
    public RubikTimer rubikTimer; // Reference to the RubikTimer script
    public HistoryManager historyManager; // Reference to the HistoryManager script
    private int currentRound = 1; // Track the current round

    void Start()
    {
        readCube = FindObjectOfType<ReadCube>();
        cubeState = FindObjectOfType<CubeState>();
        rubikTimer = FindObjectOfType<RubikTimer>(); // Get reference to RubikTimer
        historyManager = FindObjectOfType<HistoryManager>(); // Get reference to HistoryManager
    }

    void Update()
    {
        if (CubeState.started && doOnce)
        {
            doOnce = false;
            rubikTimer.StartTimer(); // Start the timer when the game starts
        }
    }

    public void Solver()
    {
        readCube.ReadState();

        // Get the state of the cube as a string
        string moveString = cubeState.GetStateString();
        print(moveString);

        // Solve the cube
        string info = "";

        // First time build the tables
        string solution = SearchRunTime.solution(moveString, out info, buildTables: true);

        // Convert the solved moves from a string to a list
        List<string> solutionList = StringToList(solution);

        // Automate the move list
        Automate.moveList = solutionList;

        // Print solution info
        print(info);

        // Stop the timer and record the elapsed time
    float elapsedTime = rubikTimer.GetElapsedTime(); // Get the elapsed time
    Debug.Log("Elapsed Time: " + elapsedTime); // Log elapsed time
    rubikTimer.StopTimer(); // Stop the timer
    historyManager.AddHistoryEntry(currentRound, elapsedTime); // Add to history
    currentRound++; // Increment the round for the next game

    // Reset the timer when the solve is triggered
    rubikTimer.ResetAndStopTimer();
    }

    List<string> StringToList(string solution)
    {
        List<string> solutionList = new List<string>(solution.Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries));
        return solutionList;
    }
}
