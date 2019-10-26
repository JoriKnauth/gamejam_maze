using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerable : MonoBehaviour
{
    [SerializeField] protected bool isTriggered;

    [SerializeField] protected Light triggerLight;

    public virtual void Triggered()
    {
        triggerLight.enabled = isTriggered;
    }
}
