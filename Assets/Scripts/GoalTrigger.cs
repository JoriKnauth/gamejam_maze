using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameManager gameManager;

    public void DOTrigger()
    {
        gameManager.Win();

        Destroy(this);
    }
}
