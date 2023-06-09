using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace EasyAudioSystem
{
    public class AudioManager : MonoBehaviour
    {
        public Sound[] sounds;

        public static AudioManager instance;


        [HideInInspector] public Sound mainStart;
        private Sound mainLoop;
        private Sound deathScreen;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);

            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }
        }

        private void Start()
        {
            Play("MainTheme");
        }

        public void Play(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.Log($"Sound: {name} not found!");
                return;
            }

            s.source.Play();
        }

        public void ChangePitchUp(string name, float increment)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.Log($"Sound: {name} not found!");
                return;
            }

            s.source.pitch += increment;
        }
        public void ResetPitch(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.Log($"Sound: {name} not found!");
                return;
            }

            s.source.pitch = 1;
        }
    }
}