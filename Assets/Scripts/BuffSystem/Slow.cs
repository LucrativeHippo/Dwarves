using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slow : MonoBehaviour {

    PlayerMovement playerMove;
    NavMeshAgent npcMove;

    private float baseSpeed;
    private float percentSlow;
    private float duration;

    private float timePassed;

    // Use this for initialization
    void Start()
    {
        
    }

    private void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > duration)
        {
            stopSlow();
            removeSlow();
        }
    }

    public float getSlowPercent()
    {
        return percentSlow;
    }

    public void setSlowPercent(float slowDecimal)
    {
        percentSlow = slowDecimal;
    }

    public float getDuration()
    {
        return duration;
    }

    public void setDuration(float dur)
    {
        duration = dur;
    }

    public void startSlow()
    {
        timePassed = 0;
        applySlow();
    }

    public void applySlow()
    {
        playerMove = gameObject.GetComponent<PlayerMovement>();
        npcMove = gameObject.GetComponent<NavMeshAgent>();

        if (playerMove != null)
        {
            baseSpeed = playerMove.speed;
            playerMove.speed *= percentSlow;
        }
        else if (npcMove != null)
        {
            baseSpeed = npcMove.speed;
            npcMove.speed *= percentSlow;
        }
    }

    public void stopSlow()
    {
        if (playerMove != null)
        {
            playerMove.speed = baseSpeed;
        }
        else if (npcMove != null)
        {
            npcMove.speed = baseSpeed;
        }
    }

    public void removeSlow()
    {
        stopSlow();
        Destroy(this);
    }
}
