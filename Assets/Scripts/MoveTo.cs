using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveTo : MonoBehaviour
{
    public Transform thisTransform;
    public float moveDuration;
    public Ease easeType;

    public Tween moveTween;
    public void Move(Vector3 position)
    {
        DOTween.Kill(moveTween);

        moveTween = thisTransform.DOMove(position, moveDuration, false).SetEase(easeType);
    }
}
