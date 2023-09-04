using System;
using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        public Sound[] sounds;

        public static AudioManager instance;

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

            foreach (var s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volume = PlayerPrefs.GetFloat("SoundVolume");
                s.source.pitch = s.pitch = 1;
                s.source.loop = s.loop;

                if (s.name == "Theme")
                {
                    s.source.volume = s.volume = PlayerPrefs.GetFloat("MusicVolume");
                }
            }
        }

        public void Play()
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);

            if (s == null)
            {
                Debug.LogWarning("Sound " + name + " not founded!");
                return;
            }
            s.source.Play();
        }
    }
}
