using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    [SerializeField] protected AudioSource audioSource;

    [ContextMenu("Play")]
    public virtual void Play()
    {
        if (!audioSource)
        {
            return;
        }
        audioSource.Play();
    }
}
