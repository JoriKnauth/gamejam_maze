using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerableDoor : Triggerable
{
    [SerializeField] private GameObject thisGameObject;

    public override void Triggered()
    {
        base.Triggered();
        isTriggered = !isTriggered;
        thisGameObject.SetActive(isTriggered);
    }
}
