﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Triggerable[] triggereable;

    private GameManager gameManager;

    private SoundEffect soundEffect;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public virtual void DOTrigger()
    {
        for (int i = 0; i < triggereable.Length; i++)
        {
            triggereable[i].Triggered();
        }

        soundEffect.Play();

        SetCamera();
    }

    public void SetCamera()
    {
        gameManager.MapCamera.ZoomOut();
    }
}
