using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Sound.MusicPlayer {
    [RequireComponent(typeof (AudioSource))]

    public class MusicPlayer : MonoBehaviour {
        [Header("Audio Clips")]
        [SerializeField] AudioClip[] Clips;
        private AudioSource AudioSource;

        [Header("Fade in")]
        // This is the duration for the fade in effect
        [SerializeField] float Duration;
        // This variable should be between 0 and 1
        [SerializeField] float TargetVolume;

        void Start() {
            AudioSource = this.gameObject.GetComponent<AudioSource>();
            AudioSource.volume = 0;

            AudioSource.loop = false;
        }

        void Update() {
            if (!AudioSource.isPlaying){
                AudioSource.clip = GetRandomClip();
                StartCoroutine(FadeAudioSource.StartFade(AudioSource, Duration, TargetVolume));
                AudioSource.Play();
            }
        }

        private AudioClip GetRandomClip() {
            return Clips[Random.Range(0, Clips.Length)];
        }
    }
}