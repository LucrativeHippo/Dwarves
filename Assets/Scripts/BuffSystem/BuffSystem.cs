using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework.Interfaces;
using System.IO.Pipes;

public class BuffSystem : MonoBehaviour {

    private GameObject npcManagerGameObject;
    private List<GameObject> theNPCs;
    private List<GameObject> theEnemies;

    private GameObject player;

    void Start () {
        // TODO: Connect NNPC Manager to this.
        //        theNPCs = npcManagerGameObject.GetComponent<NPCManager> ().getNPCsList ();

        // TODO: Get all the enemies on the map.
        //        theEnemies = 

        player = GameObject.FindGameObjectsWithTag ("Player");
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
        // TODO: Apply Specified Buff or Boon to the target.
    }

}
