using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCamera : MonoBehaviour
{
    private Transform thisTransform;
    private FollowScript followScript;
    private Camera camera;

    public void ZoomOut()
    {
        followScript.enabled = false;
    }

    private void MoveCamera()
    {

    }
}
