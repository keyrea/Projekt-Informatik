using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;
    public void playSound()
    {
        // when the method is called, play the sound effect of a button click
        audioSource.PlayOneShot(clip, volume);
    }
}
