using EasyAudioSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HARROP_CHARLIE.RandomTheft
{

    public class PlaySound : MonoBehaviour
    {
        [SerializeField] private string soundName;

        public void Play()
        {
            FindObjectOfType<AudioManager>().Play(soundName);
        }
    }
}

