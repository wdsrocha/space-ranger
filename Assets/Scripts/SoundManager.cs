using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public SoundAudioClip[] soundAudioClips;

    [System.Serializable]
    public class SoundAudioClip {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }

    public static SoundManager Instance { get; private set; }

    public enum Sound {
        AsteroidExplosion,
        ShipExplosion,
        MenuMusic,
        GameMusic,
        Laser,
        UiSelect,
        UiStart,
    }

    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void PlaySound(Sound sound)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.clip = GetAudioClip(sound);
        audioSource.Play();
    }

    public AudioSource GetAudioSource(Sound sound)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.clip = GetAudioClip(sound);
        return audioSource;

    }

    private AudioClip GetAudioClip(Sound sound) {
        foreach(SoundAudioClip soundAudioClip in soundAudioClips) {
            if (soundAudioClip.sound == sound) {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError($"Sound {sound} not found!");
        return null;
    }
}
