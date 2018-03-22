using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormOfHeatExhaustion : StormOfSlow {

    protected override void slow(GameObject victim)
    {
        if (!MetaScript.getGlobal_Stats().getHasHeatProtection())
        {
            InBuilding shelterCheck = victim.GetComponent<InBuilding>();
            if (shelterCheck == null || !shelterCheck.getPlayerInBuilding())
            {
                buffsys.slowApplyingSystem(victim, slowDuration, slowDecimal);
            }
        }
    }

}
