using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Untuk manajemen scene

public class MenuController : MonoBehaviour
{
    // Method untuk kembali ke menu utama
    public void GoToMainMenu() {
        SceneManager.LoadScene("Main Menu"); // Ganti dengan nama scene Anda
    }

    // Method untuk pergi ke halaman history
    public void GoToHistory() {
        SceneManager.LoadScene("History"); // Ganti dengan nama scene Anda
    }

    // Method untuk memulai permainan Rubik 3x3
    public void StartRubik3x3() {
        SceneManager.LoadScene("Rubik Game"); // Ganti dengan nama scene permainan Rubik 3x3 Anda
    }

    // Method untuk kembali ke Level Selection
    public void GoToLevelSelection() {
        SceneManager.LoadScene("Level Selection"); // Ganti dengan nama scene Level Selection Anda
    }

    // Method untuk pergi ke Credits
    public void GoToCredits() {
        SceneManager.LoadScene("Credit"); // Ganti dengan nama scene Credits Anda
    }
}
