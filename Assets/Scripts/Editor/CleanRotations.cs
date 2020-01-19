using UnityEngine;
using UnityEditor;

public class CleanRotations : ScriptableWizard
{
    public Transform[] Transforms;

    public bool cleanRotationX = true;
    public bool cleanRotationY = true;
    public bool cleanRotationZ = true;

    [MenuItem("Custom/Clean Rotations")]

    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard("Clean Rotations", typeof(CleanRotations), "Clean Rotations");
    }

    void OnWizardCreate()
    {
        if (Transforms.Length == 0)
        {
            return;
        }

        foreach (Transform thisTransform in Transforms)
        {
            Vector3 rot = thisTransform.eulerAngles;

            if (cleanRotationX)
            {
                rot.x = CleanRotation(rot.x, thisTransform);
            }
            if (cleanRotationY)
            {
                rot.y = CleanRotation(rot.y, thisTransform);
            }
            if (cleanRotationZ)
            {
                rot.z = CleanRotation(rot.z, thisTransform);
            }

            rot.x = Vector3.Angle(new Vector3(rot.x, 0f, 0f), thisTransform.right);
            rot.y = Vector3.Angle(new Vector3(0f, rot.y, 0f), thisTransform.up);
            rot.z = Vector3.Angle(new Vector3(0f, 0f, rot.z), thisTransform.forward);


            thisTransform.rotation = Quaternion.identity;
            thisTransform.eulerAngles = rot;

            thisTransform.rotation = Quaternion.Euler(rot);
        }
    }

    private float CleanRotation(float _value, Transform thisTransform)
    {
        float newValue = _value;

        newValue %= 360f;

        if (newValue < 0f)
        {
            newValue += 360f;
        }


        Debug.Log("old Value " + _value + " new Value " + newValue);

        return newValue;
    }
}