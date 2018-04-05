using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour, IHealthListener {	
	public GameObject opponent;
	NavMeshAgent agentCtrl;
    private Animator anim;
	public float threatRange;

    public int damage;



	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponentInChildren<Animator>();
		agentCtrl = this.GetComponent<NavMeshAgent>();
		setHealth(GetComponent<Health>());
		getDest();
		setDestination();
		tag = "Enemy";
	}
	private void getDest(){
		opponent = collect.findClosestTag("OwnedNPC",gameObject);
        if (opponent != null)
        {
            float oppDist = (transform.position - opponent.transform.position).sqrMagnitude;
            float playerDist = (transform.position - MetaScript.getPlayer().transform.position).sqrMagnitude;
            if (playerDist < oppDist)
            {
                opponent = MetaScript.getPlayer();
            }
        }
        else
        {
            opponent = MetaScript.getPlayer();
        }
	}
    // Update is called once per frame
    void Update(){
        if (opponent == null)
        {
            getDest();
        }
        else
        {
            setDestination();
        }
    }

	private void setDestination(){
		if (opponent != null) {
            if(opponent.tag.Equals("ProtectedNPC"))
            {
                getDest();
            }
			else if(!withinAttackRange()){
                anim.SetBool("attack",false);
				agentCtrl.isStopped = false;
				agentCtrl.SetDestination (opponent.transform.position);
			}else{
				agentCtrl.isStopped = true;
				if(canAttack){
					StartCoroutine(combatManager());
				}
			}
		}
	}

	private bool withinAttackRange(){
		return (opponent.transform.position - transform.position).sqrMagnitude < Mathf.Pow(threatRange,2);
	}

	private bool canAttack = true;
	private float coolDown = 2f;
	IEnumerator combatManager() {
		canAttack = false;
		combat ();
		yield return new WaitForSeconds (coolDown);
		canAttack = true;
			//UNCOMMENT this one if you want hp to drop smoothly
//			enemyStats.cur_health -= opponentDamage * Time.deltaTime;
//			timestamp = Time.time + 1.0f;
	}

	void combat(){
		Debug.Log("Combat Entered");

		if(opponent != null){
            anim.SetBool("attack", true);
			Health h = opponent.GetComponent<Health>();
			opponent.SendMessage("damage",damage);
			opponent.SendMessage("notifyNPC");
		}
	}

	private Health myHealth;
    public void setHealth(Health health)
    {
		myHealth = health;
		health.addSubscriber(this);
    }

    public void publish()
    {
		if(opponent == null || !withinAttackRange()){
			getDest();
		}
    }
}
