using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FadeAudioSource {
    public static IEnumerator StartFade(AudioSource AudioSource, float Duration, float TargetVolume){
        float currentTime = 0;
        float start = AudioSource.volume;

        while (currentTime < Duration) {
            currentTime += Time.deltaTime;

            AudioSource.volume = Mathf.Lerp(start, TargetVolume, currentTime / Duration);
            yield return null;
        }
        yield break;
    }
}