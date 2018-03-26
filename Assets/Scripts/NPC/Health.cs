using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    /// The health.
    [SerializeField]
    int health = 10;
    [SerializeField]
    int maxHealth;
    [SerializeField]
    bool isImmortal = false;
    public bool dealDamage = false;

    int originalMaxHp;
    float originalHealthMultiplier = 1;

    LinkedList<IHealthListener> subscribers = new LinkedList<IHealthListener>();

    public void addSubscriber(IHealthListener listener){
        subscribers.AddLast(listener);
    }

    public void publish(){
        foreach(IHealthListener l in subscribers){
            l.publish();
        }
    }


    public void Start () {
        maxHealth = health;
        originalMaxHp = maxHealth;
    }


    public float getHealth(){
        return health;
    }
    public float getMaxHealth(){
        return maxHealth;
    }

    /// <summary>
    /// Damage the character. Returns true if character is dead.
    /// </summary>
    /// <param name="dmg">Damage to deal.</param>
    /// <returns>True if health less than 0, false otherwise.</returns>
    /// <exception cref="UnityException">Throws if dmg is less than 0.</exception>
    public void damage (int dmg) {
        if (dmg < 0)
            throw new UnityException ("You can't heal from damage!");
            
        health -= dmg;
        publish();
        notifyNPC();
        displayDamage(dmg);
        if (health <= 0 && !isImmortal) {
            death();
        }
    }

    /// <summary>
    /// Heal the character. Only heals up to max health.
    /// </summary>
    /// <param name="heal">Amount to heal.</param>
    /// <exception cref="UnityException">Throws if heal is less than 0.</exception>
    public void healHealth (int heal) {
        if (heal < 0)
            throw new UnityException ("You can't damage from heal!");
		
        if (heal + health > maxHealth) {
            health = maxHealth;
        } else {
            health += heal;
        }
        publish();
    }

    public void damageCapacity(int dmg){
        if(dmg < 0)
            throw new UnityException ("You can't heal from damage!");

        maxHealth -= dmg;
        healHealth(0);
        damage(0);
    }

    public void healCapacity(int heal){
        if(heal < 0)
            throw new UnityException("You can't damage from heal");
        
        maxHealth += heal;
        if(maxHealth > originalMaxHp){
            maxHealth = originalMaxHp;
        }
        healHealth(heal);
    }

    public void death(){
        if(CompareTag("OwnedNPC")){
            MetaScript.GetNPC().removeNPC(gameObject);
        }
        if(CompareTag("Player")){
            GameObject sacrifice = MetaScript.GetSacrificialNPC();
            if (sacrifice == null)
            {
                Destroy(gameObject);
            }
            else
            {
                // Stop npc from moving;
                sacrifice.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = true;

                MetaScript.preTeleport();
                transform.position = sacrifice.transform.position;
                sacrifice.transform.eulerAngles = new Vector3(0, 0, 90);
                MetaScript.postTeleport();

                // TODO: Delay spawn
                // Destroy npc
                sacrifice.GetComponent<Health>().death();
                health = maxHealth;
            }
            
            
        }else{
            Destroy(gameObject);
        }
    }

    public void notifyNPC(){
        FightFlight ff = GetComponent<FightFlight>();
        if(ff!=null){
            ff.gotHit();
        }
    }

    void OnValidate() {
        if(dealDamage){
            dealDamage = false;
            damage(1);
        }
    }

    void displayDamage(float damage)
    {
        GameObject damageDealt = new GameObject();
        damageDealt.AddComponent<TextMesh>();
        damageDealt.AddComponent<MeshRenderer>();
        damageDealt.AddComponent<Rigidbody>();
        if(damage < 0)
        {
            damageDealt.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else
        {
            damageDealt.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        
        damageDealt.GetComponent<TextMesh>().text = damage.ToString();
        damageDealt.GetComponent<TextMesh>().characterSize = 0.07f;
        damageDealt.transform.position = gameObject.transform.position + new Vector3(0,0.6f,0);
        damageDealt.GetComponent<Rigidbody>().AddForce(0, 50.0f, 0);
        //damageDealt.GetComponent<Rigidbody>().useGravity = false;
        Destroy(damageDealt, 1.5f);
    }

    

    void Update()
    {
        if (originalHealthMultiplier < MetaScript.getGlobal_Stats().getHealthMultiplier() && gameObject.tag!= "Enemy")
        {
 
            originalHealthMultiplier = MetaScript.getGlobal_Stats().getHealthMultiplier();
            maxHealth = Mathf.RoundToInt(originalMaxHp * originalHealthMultiplier);
            health = maxHealth;
        }
      }
}
