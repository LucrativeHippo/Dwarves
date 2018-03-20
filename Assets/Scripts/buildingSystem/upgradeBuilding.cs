using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class upgradeBuilding : MonoBehaviour, IActionable
{
    [SerializeField]
    private Material upgradeMaterial;

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
            GameObject temp = Instantiate(upgrade, gameObject.transform.position, Quaternion.identity);
            temp.transform.parent = gameObject.transform.parent;
            gameObject.transform.parent.GetComponentsInChildren<MeshRenderer>()[0].material = upgradeMaterial;
            Destroy(gameObject);
        }
        
    }

    void Start()
    {

    }



    void Update()
    {

    }



}

