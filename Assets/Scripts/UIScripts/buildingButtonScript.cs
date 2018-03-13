using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class buildingButtonScript : MonoBehaviour {

    private int number;

    private Text nameText;
    private Text costText;

    private GameObject theBuilding;

    private basicBuilding buildingScript;

    public void setButton (int idNumber, basicBuilding aScript, GameObject aBuilding) {
        nameText = this.transform.GetChild (1).gameObject.GetComponent<Text> ();
        costText = this.transform.GetChild (2).GetChild (0).gameObject.GetComponent<Text> ();

        buildingScript = aScript;
        number = idNumber;
        theBuilding = aBuilding;

        setBuildingScript (aScript);
        setName ();
        setCost ();
        setListener ();
    }

    private void setName () {
        name = theBuilding.name;
        nameText.text = name;
    }

    private void setCost () {
        string costString = "";
        int[] costs = theBuilding.GetComponent<resourceCost> ().cost;
        var types = Enum.GetValues (typeof(ResourceTypes));

        int counter = 0;
        foreach (var cost in costs) {
            if (costs [counter] != 0) {
                costString += types.GetValue (counter).ToString () + ": " + costs [counter] + "\n";
            }
            counter++;
        }
        costText.text = costString;
    }

    private void setListener () {
        this.gameObject.GetComponent<Button> ().onClick.AddListener (() => button_Click ());
    }

    private void setBuildingScript (basicBuilding aBuildingScript) {
        buildingScript = aBuildingScript;
    }

    public void button_Click () {
        buildingScript.buttonClicked (number);
    }

}
