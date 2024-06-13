using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : Trap
{
    protected override void ApplyTrapEffect(HealthSystem healEnemy)
    {
        healEnemy.ChangeHealth(15, false);
    }
}
