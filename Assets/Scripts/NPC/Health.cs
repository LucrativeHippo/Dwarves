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

    LinkedList<IHealthListener> subscribers;

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
        subscribers = new LinkedList<IHealthListener>();
    }


    public int getHealth(){
        return health;
    }
    public int getMaxHealth(){
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
        if (health <= 0 && !isImmortal) {
            death();
        }
    }

    /// <summary>
    /// Heal the character. Only heals up to max health.
    /// </summary>
    /// <param name="heal">Amount to heal.</param>
    /// <exception cref="UnityException">Throws if heal is less than 0.</exception>
    public void heal (int heal) {
        if (heal < 0)
            throw new UnityException ("You can't damage from heal!");
		
        if (heal + health > maxHealth) {
            health = maxHealth;
        } else {
            health += heal;
        }
        publish();
    }

    public void death(){
        if(CompareTag("OwnedNPC")){
            MetaScript.GetNPC().removeNPC(gameObject);
        }
        Destroy(gameObject);
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
}
