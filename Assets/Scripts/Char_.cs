using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_ : MonoBehaviour
{
    public float raylenght;
    public float tilelenght;
    public float distanceCheck;
    public float moveDuration;

    public float buttonCooldown;
    private float nextPossibleButtonInput;

    public Transform thistransform;

    public Vector3[] directionFacing;
    public Vector3[] directionVector;

    public LayerMask collisionMask;

    private Trigger trigger;
    public Lookat lookat;
    public void Awake()
    {
        thistransform = transform;

    }



    void Update()
    {
        if (CheckButtonCoolDown())
        {
            if (Input.GetKey(KeyCode.W))
            {
                SetButtonCoolDown();
                thistransform.eulerAngles = directionFacing[0];
                if (CheckCollidion())
                {
                    Move(0);
                }
            }
            else if (Input.GetKey(KeyCode.S))
            {
                SetButtonCoolDown();
                thistransform.eulerAngles = directionFacing[1];
                if (CheckCollidion())
                {
                    Move(1);
                }
            }
            else if (Input.GetKey(KeyCode.A))
            {
                SetButtonCoolDown();
                thistransform.eulerAngles = directionFacing[2];
                if (CheckCollidion())
                {
                    Move(2);
                }
            }
            else if (Input.GetKey(KeyCode.D))
            {
                SetButtonCoolDown();
                thistransform.eulerAngles = directionFacing[3];
                if (CheckCollidion())
                {
                    Move(3);
                }
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                SetButtonCoolDown();
                if (trigger)
                {
                    trigger.DOTrigger();
                }
            }
        }
    }

    private void SetButtonCoolDown()
    {
        nextPossibleButtonInput = Time.time + buttonCooldown;
    }

    private bool CheckButtonCoolDown()
    {
        return nextPossibleButtonInput < Time.time;
    }

    private bool CheckCollidion()
    {
        Ray ray = new Ray();
        RaycastHit hit = new RaycastHit();
        ray = new Ray(thistransform.position, thistransform.forward);

        if (Physics.Raycast(ray, out hit, distanceCheck, collisionMask, QueryTriggerInteraction.Collide))
        {
            if (hit.collider != null)
            {
                return false;
            }
        }

        return true;
    }

    private void Move(int direction)
    {
        thistransform.localPosition = thistransform.localPosition + directionVector[direction] * tilelenght;

        lookat.SetLook(thistransform.position);
    }

    private bool IsWithinDistance(Vector3 postion1, Vector3 postion2)
    {
        return Vector3.Distance(postion1, postion2) < distanceCheck;
    }


    public void OnTriggerEnter(Collider other)
    {
        Trigger _trigger = other.GetComponent<Trigger>();
        if (_trigger != null)
        {
            trigger = _trigger;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Trigger _trigger = other.GetComponent<Trigger>();
        if (_trigger != null)
        {
            trigger = null;
        }
    }
}