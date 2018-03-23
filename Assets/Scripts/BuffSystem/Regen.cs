using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regen : MonoBehaviour {

    private Health characterHealth;
    private float duration;
    private float tickCooldown;
    private int healingPerTick;

    public void startRegen()
    {
        characterHealth = gameObject.GetComponent<Health>();
        if (characterHealth == null)
        {
            Debug.LogError("Error: No health script attached for Regen to find. Removing Regen.");
            removeRegen();
        }
        else
        {
            StartCoroutine("beginRegen");
        }
    }

    public void stopRegen()
    {
        StopCoroutine("beginRegen");
        StopCoroutine("applyRegen");
    }

    public void removeRegen()
    {
        stopRegen();
        Destroy(this);
    }

    public float getDuration()
    {
        return duration;
    }

    public void setDuration(float dur)
    {
        duration = dur;
    }

    public float getTickCooldown()
    {
        return tickCooldown;
    }

    public void setTickCooldown(float tickCd)
    {
        tickCooldown = tickCd;
    }

    public int getHealingPerTick()
    {
        return healingPerTick;
    }

    public void setHealingPerTick(int healPerTick)
    {
        healingPerTick = healPerTick;
    }

    private IEnumerator beginRegen()
    {
        StartCoroutine("applyRegen");
        yield return new WaitForSeconds(duration);
        removeRegen();
    }

    private IEnumerator applyRegen()
    {
        while (true)
        {
            characterHealth.heal(healingPerTick);
            yield return new WaitForSeconds(tickCooldown);
        }

    }
}
