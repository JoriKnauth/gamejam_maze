using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerable : MonoBehaviour
{
    [SerializeField] protected bool isTriggered;

    public virtual void Triggered()
    {

    }
}
