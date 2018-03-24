using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {

    GameObject player;
    Vector3Int pos;
    ParticleSystem[] ps;

    private Vector3 returnPoint;

    // Use this for initialization
    void Start () {
        
        player = MetaScript.getPlayer();

    }

    public void setReturn(int x, int y, int z)
    {
        
        pos = new Vector3Int(x,0,z);
    }

    public void recieveAction()
    {
        // }else{
        //     player.GetComponent<DynamicGeneration>().enabled = true;
        // }
        // if(pos != null)
        // {
            print(pos.x + "" + pos.y + "" + pos.z);
            player.SetActive(false);
            player.transform.position = pos;
            player.SetActive(true);

        player.GetComponent<DynamicGeneration>().enabled = true;
        player.GetComponent<InBuilding>().setPlayerInBuilding(false);
        //gameObject.GetComponent<ParticleSystem>().emission.enabled = true;
            //print(xpos + zpos);
        // }
        // else
        // {
            
        //     Debug.Log("The return building has not been set yet");
        // }
    }

    private void enableParticleSystems()
    {
        if (!player.GetComponent<InBuilding>().getPlayerInBuilding())
        {
            ps = ps = player.GetComponentsInChildren<ParticleSystem>();
            if (ps != null)
            {
                for (int i = 0; i < ps.Length; i++)
                {
                    ps[i].Play();
                }
            }
        }
    }
}
