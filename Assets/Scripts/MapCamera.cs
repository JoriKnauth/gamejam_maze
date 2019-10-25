using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MapCamera : MonoBehaviour
{
    public Transform thisTransform;
    public Transform playerTransform;
    public Transform mapOverviewPoint;
    public FollowScript followScript;

    public Char_ char_;

    public float moveInDuration;
    public float moveOutDuration;

    public float zoomIn;
    public float zoomOut;

    public Camera camera;

    public Tween moveTween;
    public Tween zoomTween;

    public void ZoomOut()
    {
        SetFollowScript(false);
        SetMoveOut(mapOverviewPoint.position);
    }

    public void ZoomIn()
    {
        SetMoveIn(playerTransform.position);
    }

    private void SetMoveOut(Vector3 position)
    {
        DOTween.Kill(moveTween);

        moveTween = thisTransform.DOMove(position, moveOutDuration, false).SetEase(Ease.InOutSine);

        DOTween.Kill(zoomTween);

        zoomTween = camera.DOOrthoSize(zoomOut, moveOutDuration);

        char_.SetZoomedOut(true);
    }

    private void SetMoveIn(Vector3 position)
    {
        DOTween.Kill(moveTween);

        moveTween = thisTransform.DOMove(position, moveInDuration, false).SetEase(Ease.InOutSine).OnComplete(EnableFollowScript); ;

        DOTween.Kill(zoomTween);

        zoomTween = camera.DOOrthoSize(zoomIn, moveInDuration);

        char_.SetZoomedOut(false);
    }

    private void SetFollowScript(bool setScript)
    {
        followScript.enabled = setScript;
    }

    private void EnableFollowScript()
    {
        SetFollowScript(true);
    }
}
