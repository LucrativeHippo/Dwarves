using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonScript : MonoBehaviour {

    private string name;
    private int number;

    public Text buttonText;
    public basicBuilding buildingScript;

    public void setName (string aName) {
        name = aName;
        buttonText.text = name;
    }

    public void setListener () {
        this.gameObject.GetComponent<Button> ().onClick.AddListener (() => button_Click ());
    }

    public void setNumber (int aNumber) {
        number = aNumber;
        setListener ();
    }

    public void setBuildingScript (basicBuilding aBuildingScript) {
        buildingScript = aBuildingScript;
    }

    public void button_Click () {
        buildingScript.buttonClicked (number);
    }
}
