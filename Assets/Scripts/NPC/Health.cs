using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour, IStatsListener {
    /// The health.
    [SerializeField]
    int health = 100;
    [SerializeField]
    int maxHealth;
    [SerializeField]
    bool isImmortal = false;
    bool isInvulnerable = false;
    public bool dealDamage = false;
    private Skills npcSkill;

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
        npcSkill = gameObject.GetComponent<Skills>();
        if (npcSkill != null)
        {
            health = Mathf.RoundToInt(50 + (npcSkill.getValue(1) * 10));
            maxHealth = health;
            originalMaxHp = maxHealth;
        }
        else
        {
            maxHealth = health;
            originalMaxHp = maxHealth;
        }
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
        
        if (isInvulnerable)
            return;

        health -= dmg;
        publish();
        
        if(CompareTag("OwnedNPC") || CompareTag("Player") || CompareTag("Enemy"))
        {
            displayDamage(dmg);
        }
       
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
            StartCoroutine(PerformRitual());
            
            
        }else{
            Destroy(gameObject);
        }
    }

    private void setPlayerBusy(bool busy){
        MetaScript.GetControls().FocusedInput = busy;
        isInvulnerable = busy;
    }
    IEnumerator PerformRitual()
    {
        GameObject sacrifice = MetaScript.GetSacrificialNPC();
        // Disable and heal player
        setPlayerBusy(true);
        health = maxHealth;
        
        // Sacrifice failed
        if (sacrifice == null) {
            // Load other scene
            Destroy(gameObject);
            gameEnds();
              }
        else
        {
            // Stop npc from moving;
            sacrifice.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            sacrifice.GetComponent<collect>().enabled = false;
            sacrifice.GetComponent<Guard>().enabled = false;
            sacrifice.GetComponent<follow>().enabled = false;

            // Teleport player;
            MetaScript.preTeleport();
            sacrifice.transform.eulerAngles = new Vector3(45, 0, 90);
            transform.position = sacrifice.transform.position;
            sacrifice.transform.position = sacrifice.transform.position + new Vector3(0.25f,0,0);

            // TODO: Delay spawn
            // Destroy npc
            yield return new WaitForSeconds(2.0f);
            sacrifice.GetComponent<Health>().death();
            MetaScript.postTeleport();
            
            
            setPlayerBusy(false);
        }
        yield return null;
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
            Debug.Log(originalHealthMultiplier);
            Debug.Log(MetaScript.getGlobal_Stats().getHealthMultiplier());
             health = Mathf.RoundToInt(originalMaxHp * originalHealthMultiplier);
             maxHealth = health;
          }
     }

    public void publish(Global_Stats stats)
    {
        if(CompareTag("OwnedNPC")){
            
        }
    }

    public void gameEnds(){
        SceneManager.LoadScene("endGame");
    }
}
