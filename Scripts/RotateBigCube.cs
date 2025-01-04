using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBigCube : MonoBehaviour
{
    private Vector2 firstPressPos;
    private Vector2 secondPressPos;
    private Vector2 currentSwipe;
    private Vector3 previousMousePosition;
    private Vector3 mouseDelta;
    private float speed = 200f;
    public GameObject target;
    public CubeState cubeState;

    private bool timerStarted = false; // Menandai apakah timer sudah dimulai

    void Update()
    {
        Swipe();
        Drag();

        // Cek kondisi Rubik selesai
        if (IsRubikSolved() && timerStarted)
        {
            FindObjectOfType<RubikTimer>().StopTimer();
            timerStarted = false; // Hindari pemanggilan berulang
            Debug.Log("Rubik Selesai! Timer Dihentikan.");
        }
    }

    void Drag()
    {
        if (Input.GetMouseButton(1))
        {
            // Trigger timer saat interaksi pertama kali
            if (!timerStarted)
            {
                FindObjectOfType<RubikTimer>().StartTimer();
                timerStarted = true;
                Debug.Log("Timer Dimulai!");
            }

            // Gerakan drag untuk memutar Rubik
            mouseDelta = Input.mousePosition - previousMousePosition;
            mouseDelta *= 0.1f; // Mengurangi kecepatan rotasi
            transform.rotation = Quaternion.Euler(mouseDelta.y, -mouseDelta.x, 0) * transform.rotation;
        }
        else
        {
            // Kembali ke target posisi secara otomatis
            if (transform.rotation != target.transform.rotation)
            {
                var step = speed * Time.deltaTime;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, step);
            }
        }
        previousMousePosition = Input.mousePosition;
    }

    void Swipe()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // Trigger timer saat interaksi pertama kali
            if (!timerStarted)
            {
                FindObjectOfType<RubikTimer>().StartTimer();
                timerStarted = true;
                Debug.Log("Timer Dimulai!");
            }

            // Ambil posisi awal mouse
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(1))
        {
            // Ambil posisi akhir mouse
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            currentSwipe.Normalize();

            // Rotasi berdasarkan arah swipe
            if (LeftSwipe(currentSwipe))
                target.transform.Rotate(0, 90, 0, Space.World);
            else if (RightSwipe(currentSwipe))
                target.transform.Rotate(0, -90, 0, Space.World);
            else if (UpLeftSwipe(currentSwipe))
                target.transform.Rotate(90, 0, 0, Space.World);
            else if (UpRightSwipe(currentSwipe))
                target.transform.Rotate(0, 0, -90, Space.World);
            else if (DownLeftSwipe(currentSwipe))
                target.transform.Rotate(0, 0, 90, Space.World);
            else if (DownRightSwipe(currentSwipe))
                target.transform.Rotate(-90, 0, 0, Space.World);
        }
    }

    // Logika arah swipe
    bool LeftSwipe(Vector2 swipe) { return swipe.x < 0 && Mathf.Abs(swipe.y) < 0.5f; }
    bool RightSwipe(Vector2 swipe) { return swipe.x > 0 && Mathf.Abs(swipe.y) < 0.5f; }
    bool UpLeftSwipe(Vector2 swipe) { return swipe.y > 0 && swipe.x < 0f; }
    bool UpRightSwipe(Vector2 swipe) { return swipe.y > 0 && swipe.x > 0f; }
    bool DownLeftSwipe(Vector2 swipe) { return swipe.y < 0 && swipe.x < 0f; }
    bool DownRightSwipe(Vector2 swipe) { return swipe.y < 0 && swipe.x > 0f; }

    // Fungsi untuk mengecek Rubik selesai
    private bool IsRubikSolved()
    {
        // Cek setiap sisi Rubik apakah memiliki warna yang sama
        return CheckSide(cubeState.front) &&
               CheckSide(cubeState.back) &&
               CheckSide(cubeState.up) &&
               CheckSide(cubeState.down) &&
               CheckSide(cubeState.left) &&
               CheckSide(cubeState.right);
    }

    // Fungsi untuk mengecek apakah semua face di satu sisi memiliki warna yang sama
    private bool CheckSide(List<GameObject> side)
    {
        if (side == null || side.Count == 0)
            return false;

        // Ambil warna face pertama di sisi
        Color firstColor = side[0].GetComponent<Renderer>().material.color;

        // Bandingkan warna setiap face di sisi tersebut
        foreach (GameObject face in side)
        {
            if (face.GetComponent<Renderer>().material.color != firstColor)
            {
                return false; // Jika ada warna berbeda, sisi ini tidak sama
            }
        }
        return true; // Semua warna sama
    }
}
