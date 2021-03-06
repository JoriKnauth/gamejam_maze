﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image[] listItems;

    public void SetListItem(int index)
    {
        if (index >= listItems.Length)
        {
            return;
        }

        listItems[index].enabled = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitButton();
        }
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
