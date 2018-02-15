using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonScript : MonoBehaviour {

    private string name;
    private int number;

    public Text buttonText;
    public basicBuilding scrollView;

    public void setName (string aName) {
        name = aName;
        buttonText.text = name;
    }

    public void setNumber (int aNumber) {
        number = aNumber;
    }

    public void button_Click () {
        scrollView.buttonClicked (number);
    }
}
