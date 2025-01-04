using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HistoryMenu : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1;
    // Method untuk kembali ke Level Selection
    public void GoToLevelSelection()
    {
        SceneManager.LoadScene("Level Selection"); // Ganti dengan nama scene Anda
    }

    public void BackButton() {
        src.clip = sfx1;
        src.Play();
    }
}
