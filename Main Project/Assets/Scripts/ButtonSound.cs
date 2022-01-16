using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume=0.5f;
    public float delay=0.5f;
    float m_LastPressTime;
    float m_PressDelay = 0.001f;
    public void playSound(){
        audioSource.PlayOneShot(clip,volume);
        
        // audioSource.PlayDelayed(delay);
    }
}
