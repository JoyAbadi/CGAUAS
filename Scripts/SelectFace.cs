using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFace : MonoBehaviour
{
    private CubeState cubeState;
    private ReadCube readCube;
    private int layerMask = 1 << 8;
    private RubikTimer rubikTimer;

    void Start()
    {
        readCube = FindObjectOfType<ReadCube>();
        cubeState = FindObjectOfType<CubeState>();
        rubikTimer = FindObjectOfType<RubikTimer>(); // Get reference to RubikTimer
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !CubeState.autoRotating)
        {
            // Read the current state of the cube            
            readCube.ReadState();

            // Raycast from the mouse towards the cube to see if a face is hit  
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f, layerMask))
            {
                GameObject face = hit.collider.gameObject;

                // Make a list of all the sides (lists of face GameObjects)
                List<List<GameObject>> cubeSides = new List<List<GameObject>>()
                {
                    cubeState.up,
                    cubeState.down,
                    cubeState.left,
                    cubeState.right,
                    cubeState.front,
                    cubeState.back
                };

                // If the face hit exists within a side
                foreach (List<GameObject> cubeSide in cubeSides)
                {
                    if (cubeSide.Contains(face))
                    {
                        // Pick it up
                        cubeState.PickUp(cubeSide);

                        // Start the side rotation logic
                        cubeSide[4].transform.parent.GetComponent<PivotRotation>().Rotate(cubeSide);

                        // Check if Rubik's Cube is solved
                        if (IsRubikSolved())
                        {
                            // Stop the timer
                            rubikTimer.StopTimer();
                            Debug.Log("Rubik's Cube Solved! Timer Stopped.");
                        }
                    }
                }
            }
        }
    }

    // Function to check if the Rubik's Cube is solved
    private bool IsRubikSolved()
    {
        // Check if each face has a single color
        return CheckSide(cubeState.front) &&
               CheckSide(cubeState.back) &&
               CheckSide(cubeState.up) &&
               CheckSide(cubeState.down) &&
               CheckSide(cubeState.left) &&
               CheckSide(cubeState.right);
    }

    // Function to check if a single side has all squares of the same color
    private bool CheckSide(List<GameObject> side)
    {
        if (side == null || side.Count == 0)
            return false;

        // Take the color of the first face
        Color firstColor = side[0].GetComponent<Renderer>().material.color;

        // Check if all faces have the same color
        foreach (GameObject face in side)
        {
            if (face.GetComponent<Renderer>().material.color != firstColor)
            {
                return false; // If any face has a different color, return false
            }
        }
        return true; // All faces have the same color
    }
}
