using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectCycle : SoundEffect
{
    public AudioClip openSound;
    public AudioClip closeSound;

    bool isTriggered;

    public override void Play()
    {
        isTriggered = !isTriggered;
        audioSource.clip = isTriggered ? openSound : closeSound;
        audioSource.Play();
    }
}
