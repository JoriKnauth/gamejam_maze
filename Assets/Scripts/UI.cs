using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI[] listItems;

    public void SetListItem(int index)
    {
        if (index >= listItems.Length)
        {
            return;
        }

        listItems[index].enabled = true;
    }
}
