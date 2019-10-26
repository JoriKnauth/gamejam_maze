using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
// CopyComponents - by Michael L. Croswell for Colorado Game Coders, LLC
// March 2010

//Modified by Kristian Helle Jespersen
//June 2011

public class CleanTransform : ScriptableWizard
{
    public GameObject[] OldObjects;

    [MenuItem("Custom/RoundTransforms")]


    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard("Object Transform to round", typeof(CleanTransform), "Round");
    }

    void OnWizardCreate()
    {
        //Transform[] Replaces;
        //Replaces = Replace.GetComponentsInChildren<Transform>();

        foreach (GameObject go in OldObjects)
        {
            Transform thisTransform = go.transform;

            Vector3 pos = thisTransform.position;

            pos.x = Mathf.Round(pos.x * 2.0f) / 2.0f;
            pos.y = Mathf.Round(pos.y * 2.0f) / 2.0f;
            pos.z = Mathf.Round(pos.z * 2.0f) / 2.0f;

            Vector3 rot = thisTransform.eulerAngles;
            rot.x = Mathf.Round(rot.x / 90) * 90;
            rot.y = Mathf.Round(rot.y / 90) * 90;
            rot.z = Mathf.Round(rot.z / 90) * 90;

            thisTransform.position = pos;
            thisTransform.eulerAngles = rot;
        }
    }
}