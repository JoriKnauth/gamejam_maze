using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Triggerable[] triggereable;



    public virtual void DOTrigger()
    {
        for (int i = 0; i < triggereable.Length; i++)
        {
            triggereable[i].Triggered();
        }

        SetCamera();
    }

    public void SetCamera()
    {

    }
}
