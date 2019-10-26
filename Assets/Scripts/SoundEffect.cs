using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [ContextMenu("Play")]
    public void Play()
    {
        audioSource.Play();
    }
}
