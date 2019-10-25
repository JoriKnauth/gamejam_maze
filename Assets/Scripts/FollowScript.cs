using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    [SerializeField] private Transform thisTransform;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float speed;


    // Update is called once per frame
    void Update()
    {
        thisTransform.position = Vector3.Lerp(thisTransform.position, targetTransform.position, Time.deltaTime * speed);
    }
}
