using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class upgradeBuilding : MonoBehaviour, IActionable
{
    [SerializeField]
    [NamedArray(typeof(ResourceTypes))]private int[] upgradeCostList = new int[(int)ResourceTypes.NumberOfTypes];

    [SerializeField]
    private GameObject upgrade;

    private bool canUpgrade = true;

    public void recieveAction()
    {
        for(int i=0; i < (int)ResourceTypes.NumberOfTypes; i++)
        {
            if (!MetaScript.getRes().hasResource(i,upgradeCostList[i]))
            {
                canUpgrade = false;
            }
        }

        if (canUpgrade)
        {
            Instantiate(upgrade, gameObject.transform.parent.transform.position, Quaternion.identity);
            Destroy(gameObject.transform.parent.gameObject);
        }
        
    }

    void Start()
    {

    }



    void Update()
    {

    }



}

