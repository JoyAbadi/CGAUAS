using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXGameplay : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1, sfx2;
    public void SolveButton() {
        src.clip = sfx1;
        src.Play();
    }

    public void ShuffleButton() {
        src.clip = sfx2;
        src.Play();
    }
}
