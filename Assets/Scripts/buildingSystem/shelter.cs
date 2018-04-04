using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shelter : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("OwnedNPC"))
        {
            FightFlight ff = other.GetComponent<FightFlight>();
            if (ff != null)
            {
                if (ff.isFleeing())
                {
                    beginToShelterNPC(other.gameObject);
                }
            }
        }
        else if (other.tag.Equals("ProtectedNPC"))
        {
            Guard g = other.GetComponent<Guard>();
            if (g.enabled)
            {
                FightFlight ff = other.GetComponent<FightFlight>();
                ff.revert();
                resetShelteredNPC(other.gameObject);
            }
            
        }
    }

    private void beginToShelterNPC(GameObject npc)
    {
        npc.tag = "ProtectedNPC";
        SpriteRenderer[] sprites = npc.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sprite in sprites)
        {
            sprite.enabled = false;
        }

        setBuildingCheckOnNPC(npc, true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("ProtectedNPC"))
        {
            resetShelteredNPC(other.gameObject);
        }
    }

    private void resetShelteredNPC(GameObject npc)
    {
        npc.tag = "OwnedNPC";
        SpriteRenderer[] sprites = npc.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sprite in sprites)
        {
            sprite.enabled = true;
        }

        setBuildingCheckOnNPC(npc, false);
    }

    private void setBuildingCheckOnNPC(GameObject npc, bool val)
    {
        InBuilding buildingCheck = npc.GetComponent<InBuilding>();
        if (buildingCheck == null)
        {
            buildingCheck = npc.AddComponent<InBuilding>();
        }
        buildingCheck.setPlayerInBuilding(val);
    }
}
