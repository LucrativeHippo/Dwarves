using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSystem : MonoBehaviour {

    private NPCManager npcManager;
    private GenerateMonster monsterGenerator;
    private GameObject player;

    void Start () {
        npcManager = GameObject.FindObjectOfType<NPCManager>();
        monsterGenerator = GameObject.FindObjectOfType<GenerateMonster>();
        player = GameObject.FindGameObjectWithTag ("Player");
    }

    /// <summary>
    /// Applies a buff or boon to all NPCs.
    /// </summary>
    /// <param name="aBuffOrBoon">A buff or boon name.</param>
    public void applyNPCs (BuffsAndBoons.Effects aBuffOrBoon, float length) {
        List<GameObject> theNPCs = npcManager.getAllNPCs();

        foreach (var aNPC in theNPCs) {
            applyTarget (aNPC, aBuffOrBoon, length);
        }
    }

    /// <summary>
    /// Applies a buff or boon to all Enemies.
    /// </summary>
    /// <param name="aBuffOrBoon">A buff or boon name.</param>
    public void applyEnemies (BuffsAndBoons.Effects aBuffOrBoon, float length) {
        LinkedList<Enemy> theEnemies = monsterGenerator.getAllEnemies();

        foreach (var aEnemy in theEnemies) {
            GameObject monster = aEnemy.gameObject;
            applyTarget (monster, aBuffOrBoon, length);
        }
    }

    /// <summary>
    /// Applies a buff or boon to the player.
    /// </summary>
    /// <param name="aBuffOrBoon">A buff or boon.</param>
    public void applyPlayer (BuffsAndBoons.Effects aBuffOrBoon, float length) {
        applyTarget (player, aBuffOrBoon, length);
    }

    /// <summary>
    /// Applies the specified buff or boon to the target GameObject.
    /// </summary>
    /// <param name="target">The Target GameObject to recieve the Buff or Boon.</param>
    /// <param name="aBuffOrBoon">A buff or boon name.</param>
    public void applyTarget (GameObject target, BuffsAndBoons.Effects aBuffOrBoon, float length) {
        switch (aBuffOrBoon) {
        case BuffsAndBoons.Effects.Burn:
            Debug.Log ("Burn applied to: " + target.name);
            burn (target, length, 2);
            break;
        case BuffsAndBoons.Effects.Bleed:
            Debug.Log ("Bleed applied to: " + target.name);
            bleed (target, length, 3);
            break;
        case BuffsAndBoons.Effects.Poison:
            Debug.Log("Poison applied to: " + target.name);
            poison(target, length, 4);
            break;
        case BuffsAndBoons.Effects.Slow:
            break;
        case BuffsAndBoons.Effects.DoubleHealth:
            break;
        case BuffsAndBoons.Effects.DoubleSpeed:
            break;
        case BuffsAndBoons.Effects.ExtraArmour:
            break;
        default:
            Debug.Log ("No Buff or Boon Specified for: " + target.name);
            break;
        }
    }


    /// <summary>
    /// Burn the specified target for the lengthTime with a tick rate of tickTime.
    /// </summary>
    /// <param name="target">target GameObject.</param>
    /// <param name="lengthTime">length time.</param>
    /// <param name="tickTime">tick time.</param>
    public void burn (GameObject target, float lengthTime, float tickTime) {
        dmgApplyingSystem (target, lengthTime, tickTime, 3, BuffsAndBoons.Effects.Burn);

    }

    /// <summary>
    /// Make the specified target bleed for the lengthTime with a tick rate of tickTime.
    /// </summary>
    /// <param name="target">target GameObject.</param>
    /// <param name="lengthTime">length time.</param>
    /// <param name="tickTime">tick time.</param>
    private void bleed(GameObject target, float lengthTime, float tickTime)
    {
        dmgApplyingSystem(target, lengthTime, tickTime, 5, BuffsAndBoons.Effects.Bleed);
    }

    /// <summary>
    /// Poison the specified target for the lengthTime with a tick rate of tickTime.
    /// </summary>
    /// <param name="target">target GameObject.</param>
    /// <param name="lengthTime">length time.</param>
    /// <param name="tickTime">tick time.</param>
    private void poison(GameObject target, float lengthTime, float tickTime)
    {
        dmgApplyingSystem(target, lengthTime, tickTime, 1, BuffsAndBoons.Effects.Poison);
    }

    /// <summary>
    /// Apply a Damage Over Time effect to the target
    /// </summary>
    /// <param name="target">target GameObject.</param>
    /// <param name="lengthTime">length time.</param>
    /// <param name="tickTime">tick time.</param>
    /// <param name="dmgPerTick">damage per tick.</param>
    /// <param name="cause">source of the damage (burn, bleed, etc).</param>
    private void dmgApplyingSystem(GameObject target, float lengthTime, float tickTime, int dmgPerTick, BuffsAndBoons.Effects cause) {

        DamageOverTime dot = null;

        DamageOverTime[] allDoTs;
        allDoTs = GetComponents<DamageOverTime>();

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

}
