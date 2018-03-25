using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class upgradeBuilding : MonoBehaviour, IActionable {
    [SerializeField]
    private Material upgradeMaterial;

    [SerializeField]
    [NamedArray(typeof(ResourceTypes))]private int[] upgradeCostList = new int[(int)ResourceTypes.NumberOfTypes];

    [SerializeField]
    private GameObject upgrade;

    private bool canUpgrade = true;

    private GameObject AllUIObjects;
    private GameObject upgradePrompt;

    private GameObject confirmButton;
    private GameObject cancelButton;

    private Text nameText;
    private Text costText;
    private Text moreResourcesRequiredText;

    public void recieveAction () {
        AllUIObjects.transform.GetChild (2).gameObject.SetActive (true);
        upgradePrompt.SetActive (true);
        nameText.text = upgrade.name.ToString ();
        string tempCostString = "";
        for (int i = 0; i < (int)ResourceTypes.NumberOfTypes; i++) {
            if (!MetaScript.getRes ().hasResource (i, upgradeCostList [i])) {
                canUpgrade = false;
            }
            if (upgradeCostList [i] > 0) {
                tempCostString += ((ResourceTypes)i).ToString () + ": " + upgradeCostList [i].ToString () + "\n";
            }
        }
        costText.text = tempCostString;
        moreResourcesRequiredText.text = "";
        setListener ();
    }

    void doUpgrade () {
        if (canUpgrade) {
            GameObject temp = Instantiate (upgrade, gameObject.transform.position, Quaternion.identity);
            temp.transform.parent = gameObject.transform.parent;
            gameObject.transform.parent.GetComponentsInChildren<MeshRenderer> () [0].material = upgradeMaterial;
            Destroy (gameObject);
            closePrompt ();
        } else {
            moreResourcesRequiredText.text = "More Resources Required.";
        }
    }

    void Start () {
        AllUIObjects = GameObject.Find ("AllUIObjectsCanvas");
        upgradePrompt = AllUIObjects.transform.GetChild (2).GetChild (1).gameObject;
        confirmButton = upgradePrompt.transform.GetChild (0).gameObject;
        cancelButton = upgradePrompt.transform.GetChild (1).gameObject;
        costText = upgradePrompt.transform.GetChild (2).gameObject.GetComponent<Text> ();
        nameText = upgradePrompt.transform.GetChild (3).gameObject.GetComponent<Text> ();
        moreResourcesRequiredText = upgradePrompt.transform.GetChild (4).gameObject.GetComponent<Text> ();
    }

    private void setListener () {
        confirmButton.GetComponent<Button> ().onClick.AddListener (() => doUpgrade ());
        cancelButton.GetComponent<Button> ().onClick.AddListener (() => closePrompt ());
    }

    private void closePrompt () {
        upgradePrompt.SetActive (false);
        AllUIObjects.transform.GetChild (2).gameObject.SetActive (false);
    }
}

