using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : MonoBehaviour {

    private Health characterHealth;
    private float duration;
    private float tickCooldown;
    private int damagePerTick;

    private BuffsAndBoons.Effects cause;

    public void startDoT()
    {
        characterHealth = gameObject.GetComponent<Health>();
        if (characterHealth == null)
        {
            Debug.LogError("Error: No health script attached for DamageOverTime to find. Removing DoT.");
            removeDoT();
        }
        else
        {
            StartCoroutine("beginDoT");
        }
    }

    public void stopDoT()
    {
        StopCoroutine("beginDot");
        StopCoroutine("applyDot");
    }

    public void removeDoT()
    {
        stopDoT();
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

    public int getDamagePerTick()
    {
        return damagePerTick;
    }

    public void setDamagePerTick(int dmgPerTick)
    {
        damagePerTick = dmgPerTick;
    }

    public BuffsAndBoons.Effects getCause()
    {
        return cause;
    }

    public void setCause (BuffsAndBoons.Effects theCause)
    {
        cause = theCause;
    }

    private IEnumerator beginDoT()
    {
        StartCoroutine("applyDoT");
        yield return new WaitForSeconds(duration);
        removeDoT();
    }

    private IEnumerator applyDoT()
    {
        while(true)
        {
            characterHealth.damage(damagePerTick);
            yield return new WaitForSeconds(tickCooldown);
        }

    }
}
