using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class outPost : MonoBehaviour {


    public int actionCooldownSec = 5;

    private bool canSend = true;

    private GameObject[] buildingPrefabs;
    private Object[] buildingPrefabsObjects;

    void Start()
    {
        buildingPrefabs = Resources.LoadAll("Prefabs/Outpost_Buildings", typeof(GameObject)).Cast<GameObject>().ToArray();
        buildingPrefabsObjects = buildingPrefabs;
        controls = MetaScript.GetControls();
    }
    
    private Controls controls;
    // Update is called once per frame
    void Update () {
        if (controls.keyDown(controls.Outpost) && canSend && buildingPrefabs[0].GetComponent<resourceCost>().canAfford())
        {
            if (MetaScript.getOPController().checkDistance(transform.position))
            {
                if (MetaScript.getOPController().canAddOutPost())
                {
                    // Build surrounding area to avoid nav issues
                    MetaScript.getPlayer().GetComponent<DynamicGeneration>().generateSurrounding(Chunk.getChunkPos(transform.position));
                    canSend = false;
                    buildingPrefabs[0].GetComponent<resourceCost>().purchase();
                    Instantiate(buildingPrefabsObjects[0], gameObject.transform.position, Quaternion.identity);
                    StartCoroutine(canSendTimer());
                    MetaScript.getOPController().addOutpost();
                }
                else
                {
                    Debug.Log("Already at the outpost limit");
                }
            }
            else
            {
                Debug.Log("Campfire too close to other campfire or TC");
            }
            
        }
    }

    void SendMessage()
    {
        canSend = true;
    }


    IEnumerator canSendTimer()
    {
        canSend = false;

        for (int i = 0; i < actionCooldownSec; i++)
        {
            yield return new WaitForSeconds(1.0f);
        }

        canSend = true;
    }
}
