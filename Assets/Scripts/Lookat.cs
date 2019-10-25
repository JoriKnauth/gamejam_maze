using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Lookat : MonoBehaviour
{
    [SerializeField] private Transform thisTransform;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float speed;

    private Tween lookTween;

    public void SetLook(Vector3 _lookAtPosition)
    {
        DOTween.Kill(lookTween);

        lookTween = thisTransform.DOLookAt(_lookAtPosition, speed, AxisConstraint.Y).SetEase(Ease.Linear);
    }
}
