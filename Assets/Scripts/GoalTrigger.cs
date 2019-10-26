using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : Trigger
{
    public GameManager gameManager;

    public override void DOTrigger()
    {
        gameManager.Win();

        Destroy(this);
    }
}
