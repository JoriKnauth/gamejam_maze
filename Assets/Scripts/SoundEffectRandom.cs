using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectRandom : SoundEffect
{

    [SerializeField] private AudioClip[] audioClips;
    public override void Play()
    {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length - 1)];
        audioSource.Play();
    }
}
