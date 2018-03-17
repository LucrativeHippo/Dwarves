using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class outPost : MonoBehaviour {

    public KeyCode actionKey;

    public int actionCooldownSec = 5;

    private bool canSend = true;

    private GameObject[] buildingPrefabs;
    private Object[] buildingPrefabsObjects;

    void Start()
    {
        buildingPrefabs = Resources.LoadAll("Prefabs/Outpost_Buildings", typeof(GameObject)).Cast<GameObject>().ToArray();
        buildingPrefabsObjects = buildingPrefabs;
    }
    

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(actionKey) && canSend && buildingPrefabs[0].GetComponent<resourceCost>().canAfford())
        {
            if (MetaScript.getOPController().checkDistance(gameObject.transform.position))
            {
                if (MetaScript.getOPController().canAddOutPost())
                {
                    canSend = false;
                    buildingPrefabs[0].GetComponent<resourceCost>().purchase();
                    Instantiate(buildingPrefabsObjects[0], gameObject.transform.position, Quaternion.identity);
                    StartCoroutine(canSendTimer());
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
