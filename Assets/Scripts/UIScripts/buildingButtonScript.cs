using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class buildingButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    private int number;

    private Text nameText;
    private Text costText;

    private Text descriptionText;
    private GameObject descriptionBox;

    private GameObject theBuilding;

    private basicBuilding buildingScript;

    private GameObject buildingImage;

    public void setButton (int idNumber, basicBuilding aScript, GameObject aBuilding) {
        buildingImage = this.transform.GetChild (0).gameObject;
        nameText = this.transform.GetChild (1).gameObject.GetComponent<Text> ();
        costText = this.transform.GetChild (2).GetChild (0).gameObject.GetComponent<Text> ();
        descriptionBox = this.transform.GetChild (3).gameObject;
        descriptionText = descriptionBox.transform.GetChild (0).gameObject.GetComponent<Text> ();

        buildingScript = aScript;
        number = idNumber;
        theBuilding = aBuilding;

        setBuildingScript (aScript);
        setName ();
        setCost ();
        setListener ();
        setDescription ();
        setImage ();
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

    private void setImage () {
        buildingImage.GetComponent<Image> ().sprite = theBuilding.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite;
    }

    private void setListener () {
        this.gameObject.GetComponent<Button> ().onClick.AddListener (() => button_Click ());
    }

    private void setBuildingScript (basicBuilding aBuildingScript) {
        buildingScript = aBuildingScript;
    }

    public void button_Click () {
		Debug.Log ("Play built a :"+nameText.text);
        buildingScript.buttonClicked (number);
    }

    private void setDescription () {
        descriptionText.text = theBuilding.GetComponent<resourceCost> ().getBuildingDescription ();
    }

    public void OnPointerEnter (PointerEventData eventData) {
        descriptionBox.SetActive (true);
    }

    public void OnPointerExit (PointerEventData eventData) {
        descriptionBox.SetActive (false);
    }
}
