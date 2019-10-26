using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TriggerableDoor : Triggerable
{
    [SerializeField] private GameObject thisGameObject;

    public Transform thisTransform;
    public Transform playerTransform;

    public float moveDuration;

    public Vector3 up;
    public Vector3 down;

    public Ease easeType;

    public Tween moveTween;

    public override void Triggered()
    {
        base.Triggered();
        isTriggered = !isTriggered;
        thisGameObject.SetActive(isTriggered);

        SetMoveOut(isTriggered ? up : down);
    }

    private void SetMoveOut(Vector3 position)
    {
        DOTween.Kill(moveTween);


        moveTween = thisTransform.DOLocalMove(position, moveDuration, false).SetEase(easeType);
    }
}
