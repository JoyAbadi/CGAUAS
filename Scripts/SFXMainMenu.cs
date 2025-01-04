using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Tambahkan ini untuk mengelola scene

public class SFXMainMenu : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1, sfx2, sfx3;

    public void PlayButton() {
        src.clip = sfx3;
        src.Play();
        StartCoroutine(LoadSceneWithDelay("Level Selection", src.clip.length)); // Pindah scene setelah suara selesai
    }

    public void CreditsButton() {
        src.clip = sfx1;
        src.Play();
    }

    public void SettingsButton() {
        src.clip = sfx1;
        src.Play();
    }

    public void BackButton() {
        src.clip = sfx2;
        src.Play();
    }

    private IEnumerator LoadSceneWithDelay(string sceneName, float delay) {
        yield return new WaitForSeconds(delay); // Tunggu sampai suara selesai
        SceneManager.LoadScene("Level Selection"); // Pindah ke scene yang ditentukan
    }
}
