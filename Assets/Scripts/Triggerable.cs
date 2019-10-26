using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerable : MonoBehaviour
{
    [SerializeField] protected bool isTriggered;

    [SerializeField] protected Light triggerLight;

    [SerializeField] protected SoundEffect soundEffect;

    [ContextMenu("Trigger")]
    public virtual void Triggered()
    {
        triggerLight.enabled = isTriggered;
        soundEffect.Play();
    }
}
