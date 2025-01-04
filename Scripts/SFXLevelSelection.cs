using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Tambahkan ini untuk mengelola scene

public class SFLevelSelection : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1, sfx2, sfx3;

    public void PlayButton1() {
        src.clip = sfx3;
        src.Play();
        StartCoroutine(LoadSceneWithDelay("Rubik Game", src.clip.length)); // Pindah scene setelah suara selesai
    }

    public void HistoryButton() {
        src.clip = sfx1;
        src.Play();
    }

    public void BackButtonButton() {
        src.clip = sfx2;
        src.Play();
    }


    private IEnumerator LoadSceneWithDelay(string sceneName, float delay) {
        yield return new WaitForSeconds(delay); // Tunggu sampai suara selesai
        SceneManager.LoadScene(sceneName); // Pindah ke scene yang ditentukan
    }
}
