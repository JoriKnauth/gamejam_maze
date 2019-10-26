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

    private bool isZoomedOut;
    public MapCamera mapCamera;

    public UI uI;

    public MoveTo moveTo;

    public GameManager gameManager;
    void Update()
    {
        if (CheckButtonCoolDown())
        {
            if (Input.anyKey)
            {
                SetButtonCoolDown();
                if (Input.GetKey(KeyCode.Space))
                {
                    if (trigger)
                    {
                        trigger.DOTrigger();
                    }
                }
                else if (isZoomedOut)
                {
                    mapCamera.ZoomIn();
                }
            }

            if (Input.GetKey(KeyCode.W))
            {
                thistransform.eulerAngles = directionFacing[0];
                if (CheckCollidion())
                {
                    Move(0);
                }
            }
            else if (Input.GetKey(KeyCode.S))
            {
                thistransform.eulerAngles = directionFacing[1];
                if (CheckCollidion())
                {
                    Move(1);
                }
            }
            else if (Input.GetKey(KeyCode.A))
            {
                thistransform.eulerAngles = directionFacing[2];
                if (CheckCollidion())
                {
                    Move(2);
                }
            }
            else if (Input.GetKey(KeyCode.D))
            {
                thistransform.eulerAngles = directionFacing[3];
                if (CheckCollidion())
                {
                    Move(3);
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

        moveTo.Move(thistransform.position);

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
            return;
        }

        Collectable _collectable = other.GetComponent<Collectable>();
        if (_collectable != null)
        {
            uI.SetListItem(_collectable.ID);

            _collectable.thisGameObject.SetActive(false);
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

    public void SetZoomedOut(bool _isZoomedOut)
    {
        isZoomedOut = _isZoomedOut;
    }
}