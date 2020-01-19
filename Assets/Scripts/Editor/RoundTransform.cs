using UnityEngine;
using UnityEditor;

public class RoundTransform : ScriptableWizard
{
    public Transform[] Transforms;

    public float roundPositionTo = 0.5f;
    private float roundPositionToValue;
    private bool roundPositionBiggerThanOne;
    public bool roundPositionX = true;
    public bool roundPositionY = true;
    public bool roundPositionZ = true;

    public float roundRotationTo = 90f;
    private float roundRotationToValue;
    private bool roundRotationBiggerThanOne;
    public bool roundRotationX = true;
    public bool roundRotationY = true;
    public bool roundRotationZ = true;

    [MenuItem("Custom/Round Transforms")]

    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard("Round Transforms", typeof(RoundTransform), "Round Transforms");
    }

    void OnWizardCreate()
    {
        if (Transforms.Length == 0)
        {
            return;
        }

        if (roundPositionTo < 1)
        {
            if (roundPositionTo == 0)
            {
                return;
            }
            roundPositionBiggerThanOne = false;
            roundPositionToValue = 1f / roundPositionTo;
        }
        else
        {
            roundPositionBiggerThanOne = true;
            roundPositionToValue = roundPositionTo;
        }

        if (roundRotationTo < 1)
        {
            if (roundRotationTo == 0)
            {
                return;
            }
            roundRotationBiggerThanOne = false;
            roundRotationToValue = 1f / roundRotationTo;
        }
        else
        {
            roundRotationBiggerThanOne = true;
            roundRotationToValue = roundRotationTo;
        }



        foreach (Transform thisTransform in Transforms)
        {
            Vector3 pos = thisTransform.position;

            if (roundPositionX)
            {
                pos.x = roundPositionBiggerThanOne ? RoundToWholeNumbers(pos.x, roundPositionToValue) : RoundToFraction(pos.x, roundPositionToValue);
            }
            if (roundPositionY)
            {
                pos.y = roundPositionBiggerThanOne ? RoundToWholeNumbers(pos.y, roundPositionToValue) : RoundToFraction(pos.y, roundPositionToValue);
            }
            if (roundPositionZ)
            {
                pos.z = roundPositionBiggerThanOne ? RoundToWholeNumbers(pos.z, roundPositionToValue) : RoundToFraction(pos.z, roundPositionToValue);
            }


            Vector3 rot = thisTransform.eulerAngles;

            if (roundRotationX)
            {
                rot.x = roundRotationBiggerThanOne ? RoundToWholeNumbers(rot.x, roundRotationToValue) : RoundToFraction(rot.x, roundRotationToValue);
            }
            if (roundRotationY)
            {
                rot.y = roundRotationBiggerThanOne ? RoundToWholeNumbers(rot.y, roundRotationToValue) : RoundToFraction(rot.y, roundRotationToValue);
            }
            if (roundRotationZ)
            {
                rot.z = roundRotationBiggerThanOne ? RoundToWholeNumbers(rot.z, roundRotationToValue) : RoundToFraction(rot.z, roundRotationToValue);
            }

            thisTransform.eulerAngles = rot;
            thisTransform.position = pos;

        }

    }

    private float RoundToFraction(float _value, float roundTo)
    {
        return Mathf.Round(_value * roundTo) / roundTo;
    }

    private float RoundToWholeNumbers(float _value, float roundTo)
    {
        return Mathf.Round(_value / roundTo) * roundTo;
    }
}