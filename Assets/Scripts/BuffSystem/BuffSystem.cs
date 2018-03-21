using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSystem {

    /// <summary>
    /// Apply a Slow effect to the target
    /// </summary>
    /// <param name="target">target GameObject.</param>
    /// <param name="duration">length time.</param>
    /// <param name="decimalSlow">0 - 1 where 1 is base.</param>
    public void slowApplyingSystem (GameObject target, float duration, float decimalSlow)
    {
        Slow slow = null;
        slow = target.GetComponent<Slow>();

        if (slow == null)
        {
            slow = target.AddComponent<Slow>();
        }
        else
        {
            slow.stopSlow();
        }

        slow.setSlowPercent(decimalSlow);
        slow.setDuration(duration);

        slow.startSlow();
    }

    /// <summary>
    /// Apply a Damage Over Time effect to the target
    /// </summary>
    /// <param name="target">target GameObject.</param>
    /// <param name="lengthTime">length time.</param>
    /// <param name="tickTime">tick time.</param>
    /// <param name="dmgPerTick">damage per tick.</param>
    /// <param name="cause">source of the damage (burn, bleed, etc).</param>
    public void dmgApplyingSystem(GameObject target, float lengthTime, float tickTime, int dmgPerTick, BuffsAndBoons.Effects cause) {

        DamageOverTime dot = null;

        DamageOverTime[] allDoTs;
        allDoTs = target.GetComponents<DamageOverTime>();

        foreach (DamageOverTime existingDoT in allDoTs)
        {
            if (existingDoT.getCause() == cause)
            {
                dot = existingDoT;
            }
        }

        if (dot == null)
        {
            dot = target.AddComponent<DamageOverTime>();
            dot.setCause(cause);
        }
        else
        {
            dot.stopDoT();
        }

        // A tenth of a second is added to the duration to ensure the last bit of a damage tick
        // can go off. If the last tick goes off as the DoT destroys itself, it doesn't seem
        // to apply.
        dot.setDuration(lengthTime + 0.1f);
        dot.setTickCooldown(tickTime);
        dot.setDamagePerTick(dmgPerTick);

        dot.startDoT();
    }


    /// <summary>
    /// Apply a Regen effect to the target
    /// </summary>
    /// <param name="target">target GameObject.</param>
    /// <param name="lengthTime">length time.</param>
    /// <param name="tickTime">tick time.</param>
    /// <param name="healingPerTick">healing per tick.</param>
    public void regenApplyingSystem(GameObject target, float lengthTime, float tickTime, int healingPerTick)
    {

        Regen hot = target.GetComponent<Regen>();
   
        if (hot == null)
        {
            hot = target.AddComponent<Regen>();
        }
        else
        {
            hot.stopRegen();
        }

        // A tenth of a second is added to the duration to ensure the last bit of a damage tick
        // can go off. If the last tick goes off as the DoT destroys itself, it doesn't seem
        // to apply.
        hot.setDuration(lengthTime + 0.1f);
        hot.setTickCooldown(tickTime);
        hot.setHealingPerTick(healingPerTick);

        hot.startRegen();
    }
}
