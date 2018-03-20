using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownPortal : MonoBehaviour {

    public KeyCode actionKey;

    [SerializeField]
    private float timer = 2.0f;

    private float timer2;

    private GameObject player;

    [SerializeField]
    private int resourceCost = 1;

    [SerializeField]
    private ResourceTypes costType = ResourceTypes.DIAMOND;

    private void Start()
    {
        timer2 = timer;
        player = GameObject.Find("player").gameObject.GetComponentInChildren<actor>().gameObject;
    }

    // Update is called once per frame
    void Update () {
        if (player != null)
        {
            if (Input.GetKey(actionKey))
            {

                if (MetaScript.getRes().hasResource(costType, resourceCost))
                {
                    MetaScript.getRes().addResource(costType,-resourceCost);
                   transform.parent.transform.position = GameObject.FindGameObjectWithTag("TownCenter").transform.position + new Vector3(0.5f, 0, -0.5f);
                }

            }
        }
    }

    public bool CoolDown()
    {
        timer += Time.deltaTime;

        if (timer >= timer2)
        {
            timer = 0;
            return true;

        }
        return false;
    }
}
