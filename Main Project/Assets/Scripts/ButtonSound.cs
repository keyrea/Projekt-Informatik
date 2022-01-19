// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;
    public void playSound()
    {
        // при вызове метода воспроивести звуковой эффект нажатия кнопки
        audioSource.PlayOneShot(clip, volume);
    }
}
