using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Triggerable[] triggereable;

    private GameManager gameManager;

    public SoundEffect soundEffect;

    public Renderer renderer;
    private Material material;

    public Color EmissionColorEnabled;
    public Color EmissionColorDisabled;

    private bool isTriggered;

    private void Awake()
    {
        material = renderer.material;
        material.SetColor("_EmissionColor", EmissionColorDisabled);
    }

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public virtual void DOTrigger()
    {
        isTriggered = !isTriggered;

        for (int i = 0; i < triggereable.Length; i++)
        {
            triggereable[i].Triggered();
        }

        soundEffect.Play();

        SetCamera();

        material.SetColor("_EmissionColor", isTriggered ? EmissionColorEnabled : EmissionColorDisabled);
    }

    public void SetCamera()
    {
        gameManager.MapCamera.ZoomOut();
    }
}
