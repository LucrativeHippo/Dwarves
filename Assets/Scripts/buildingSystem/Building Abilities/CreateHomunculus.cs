using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateHomunculus : MonoBehaviour, IActionable {

    [SerializeField]
    [NamedArray(typeof(ResourceTypes))]
    private int[] homunculusCostList = new int[(int)ResourceTypes.NumberOfTypes];

    [SerializeField]
    private GameObject homunculus;

    private bool canBuy = true;

    private GameObject AllUIObjects;
    private GameObject upgradePrompt;

    private GameObject confirmButton;
    private GameObject cancelButton;

    private Text nameText;
    private Text costText;
    private Text moreResourcesRequiredText;
    private Text upgradeTitleText;

    public void recieveAction()
    {
        AllUIObjects.transform.GetChild(2).gameObject.SetActive(true);
        upgradePrompt.SetActive(true);
        nameText.text = "Homunculus";
        upgradeTitleText.text = "Create";
        string tempCostString = "";
        for (int i = 0; i < (int)ResourceTypes.NumberOfTypes; i++)
        {
            if (!MetaScript.getRes().hasResource(i, homunculusCostList[i]))
            {
                canBuy = false;
            }
            if (homunculusCostList[i] > 0)
            {
                tempCostString += ((ResourceTypes)i).ToString() + ": " + homunculusCostList[i].ToString() + "\n";
            }
        }
        costText.text = tempCostString;
        moreResourcesRequiredText.text = "";
        setListener();
    }

    void doUpgrade()
    {
        Debug.Log("Player bought a :" + nameText.text);
        if (canBuy)
        {
            GameObject temp = Instantiate(homunculus, gameObject.transform.position + new Vector3(0.2f, 0.06666667f, -0.1f), Quaternion.identity);
            closePrompt();
        }
        else {
            moreResourcesRequiredText.text = "More Resources Required.";
        }
    }

    void Start()
    {
        AllUIObjects = GameObject.Find("AllUIObjectsCanvas");
        upgradePrompt = AllUIObjects.transform.GetChild(2).GetChild(1).gameObject;
        confirmButton = upgradePrompt.transform.GetChild(0).gameObject;
        cancelButton = upgradePrompt.transform.GetChild(1).gameObject;
        costText = upgradePrompt.transform.GetChild(2).gameObject.GetComponent<Text>();
        nameText = upgradePrompt.transform.GetChild(3).gameObject.GetComponent<Text>();
        moreResourcesRequiredText = upgradePrompt.transform.GetChild(4).gameObject.GetComponent<Text>();
        upgradeTitleText = upgradePrompt.transform.GetChild(5).gameObject.GetComponent<Text>();
    }

    private void setListener()
    {
        confirmButton.GetComponent<Button>().onClick.RemoveAllListeners();
        cancelButton.GetComponent<Button>().onClick.RemoveAllListeners();
        confirmButton.GetComponent<Button>().onClick.AddListener(() => doUpgrade());
        cancelButton.GetComponent<Button>().onClick.AddListener(() => closePrompt());
    }

    private void closePrompt()
    {
        upgradePrompt.SetActive(false);
        AllUIObjects.transform.GetChild(2).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
