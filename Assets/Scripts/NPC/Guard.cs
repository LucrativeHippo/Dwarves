﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour {

    [SerializeField]
    private int threatRange = 1;
    private GameObject target;
    private UnityEngine.AI.NavMeshAgent navComponent;

    public float patrolRadius;
    public float patrolTimer;

    private Transform targetPosition;
    private float timer;

    public bool enemyInRange = false;

    void Awake()
    {
        navComponent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        timer = patrolTimer;
    }
    // Use this for initialization
    void Start () {
       
        navComponent = this.transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {

        if (enemyInRange)
        {
            target = GameObject.FindWithTag("Enemy");
        }
        if (target != null)
        {

            float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

            if (distanceToTarget <= threatRange)
            {

                navComponent.isStopped = true;
                if (canAttack)
                {
                    
                    StartCoroutine(combatManager());
                }

            }
            else {
                navComponent.isStopped = false;
                navComponent.SetDestination(target.transform.position);

            }
        }
        else
        {
            Patrol();
        }
        
    }


    private bool withinAttackRange()
    {
        return (target.transform.position - transform.position).sqrMagnitude < Mathf.Pow(threatRange, 2);
    }

    private bool canAttack = true;
    private float coolDown = 2f;
    IEnumerator combatManager()
    {
        canAttack = false;
        combat();
        yield return new WaitForSeconds(coolDown);
        canAttack = true;
        //UNCOMMENT this one if you want hp to drop smoothly
        //			enemyStats.cur_health -= opponentDamage * Time.deltaTime;
        //			timestamp = Time.time + 1.0f;
    }

    void combat()
    {
        Debug.Log("Combat Entered");
        if (target != null)
        {
            target.GetComponent<Health>().damage(1);

        }
    }




    
    // Update is called once per frame
    void Patrol()
    {
        timer += Time.deltaTime;

        if (timer >= patrolTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, patrolRadius, -1);
            navComponent.SetDestination(newPos);
            timer = 0;
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        UnityEngine.AI.NavMeshHit navHit;

        UnityEngine.AI.NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}