using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : Triggerable
{
    public GameManager gameManager;

    public override void Triggered()
    {
        base.Triggered();
        gameManager.Win();
    }
}
