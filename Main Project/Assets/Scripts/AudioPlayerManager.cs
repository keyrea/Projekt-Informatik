﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// public class MuteSoundBackground : MonoBehaviour
// {
//     public void MuteToggle (bool muted)
//     {
//         if (muted)
//         {
//             AudioListener.volume = 1;
//         }
//         else
//         {
//             AudioListener.volume = 0;
//         }
//     }
// }

public class AudioPlayerManager: MonoBehaviour
{
      private static AudioPlayerManager instance = null;
      private AudioSource audio;

      private void Awake()
      {
          if (instance == null)
          { 
               instance = this;
               DontDestroyOnLoad(gameObject);
               return;
          }
          if (instance == this) return; 
          Destroy(gameObject);
      }

      void Start()
      {
         audio = GetComponent<AudioSource>();
         audio.Play();
      }
}