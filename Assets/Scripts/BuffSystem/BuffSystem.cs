using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSystem : MonoBehaviour {

    private GameObject npcManagerGameObject;
    private List<GameObject> theNPCs;
    private List<GameObject> theEnemies;

    private GameObject player;

    void Start () {
        // TODO: Connect NPC Manager to this.
        //        theNPCs = npcManagerGameObject.GetComponent<NPCManager> ().getNPCsList ();

        // TODO: Get all the enemies on the map.
        //        theEnemies = 

        player = GameObject.FindGameObjectWithTag ("Player");
    }

    /// <summary>
    /// Applies a buff or boon to all NPCs.
    /// </summary>
    /// <param name="aBuffOrBoon">A buff or boon name.</param>
    public void applyNPCs (BuffsAndBoons aBuffOrBoon) {
        foreach (var aNPC in theNPCs) {
            applyTarget (aNPC, aBuffOrBoon);
        }
    }

    /// <summary>
    /// Applies a buff or boon to all Enemies.
    /// </summary>
    /// <param name="aBuffOrBoon">A buff or boon name.</param>
    public void applyEnemies (BuffsAndBoons aBuffOrBoon) {
        foreach (var aEnemy in theEnemies) {
            applyTarget (aEnemy, aBuffOrBoon);
        }
    }

    /// <summary>
    /// Applies a buff or boon to the player.
    /// </summary>
    /// <param name="aBuffOrBoon">A buff or boon.</param>
    public void applyPlayer (BuffsAndBoons aBuffOrBoon) {
        applyTarget (player, aBuffOrBoon);
    }

    /// <summary>
    /// Applies the specified buff or boon to the target GameObject.
    /// </summary>
    /// <param name="target">The Target GameObject to recieve the Buff or Boon.</param>
    /// <param name="aBuffOrBoon">A buff or boon name.</param>
    public void applyTarget (GameObject target, BuffsAndBoons aBuffOrBoon) {
        switch (aBuffOrBoon) {
        case BuffsAndBoons.Boons.Burn:
            Debug.Log ("Burn applied to: " + target.name);
            burn (target, 5, 5);
            break;
        case BuffsAndBoons.Boons.Bleed:
            bleed (target, 5, 5);
            break;
        case BuffsAndBoons.Boons.Poison:
            break;
        case BuffsAndBoons.Boons.Slow:
            break;
        case BuffsAndBoons.Buffs.DoubleHealth:
            break;
        case BuffsAndBoons.Buffs.DoubleSpeed:
            break;
        case BuffsAndBoons.Buffs.ExtraArmour:
            break;
        default:
            Debug.Log ("No Buff or Boon Specified for: " + target.name);
            break;
        }
    }


    /// <summary>
    /// Burn the specified target for the lengthTime with a tick rate of tickTime.
    /// </summary>
    /// <param name="TargetJoint2D">target GameObject.</param>
    /// <param name="lengthTime">length time.</param>
    /// <param name="tickTime">tick time.</param>
    public void burn (GameObject target, int lengthTime, int tickTime) {
        dmgApplyingSystem (target, lengthTime, tickTime, 5);

    }

    private void dmgApplyingSystem (GameObject target, int tickTime, int lengthTime, int dmgPerTick) {
        bool tickBool = true;
        bool lengthBool;

        StartCoroutine (applyTimer ((float)lengthTime, lengthBool));
        while (lengthBool) {
            Debug.Log ("Applying.");
            if (tickBool) {
                Debug.Log ("Ticked.");
                dealDMG (target, dmgPerTick);
                StartCoroutine (tickTimer ((float)tickTime, tickBool));
            }
        }
    }

    private void timerApplyingSystem () {
        
    }

    private void bleed (GameObject target, int i, int i2) {
        throw new System.NotImplementedException ();
    }

    IEnumerator tickTimer (float time, bool tickBool) {
        tickBool = false;
        yield return new WaitForSeconds (time);
        tickBool = true;
    }

    IEnumerator applyTimer (float time, bool applyBool) {
        applyBool = true;
        yield return new WaitForSeconds (time);
        applyBool = false;
    }

    private void dealDMG (GameObject target, int dmg) {
        // TODO: Connect to DMG/Health System.
        Debug.Log ("Dealt DMG.");
    }
}
