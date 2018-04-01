using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class moreDetailsUIController : MonoBehaviour, IHealthListener {

    private GameObject currentNPC;

    [SerializeField] private GameObject moreDetailsGameObject;
    [SerializeField] private GameObject selectRoleGameObject;

    [SerializeField] private InputField nameInputField;
    [SerializeField] private Text currentJobText;
    [SerializeField] private Text healthText;

    [SerializeField] private Button selectRoleButton;

    private Health npcHealth;

    public void setNPC (GameObject newNPC) {
        moreDetailsGameObject = this.gameObject;
        selectRoleGameObject = moreDetailsGameObject.transform.parent.GetChild (2).gameObject;

        nameInputField = moreDetailsGameObject.transform.GetChild (0).GetChild (1).gameObject.GetComponent<InputField> ();

        currentJobText = moreDetailsGameObject.transform.GetChild (0).GetChild (2).GetChild (1).gameObject.GetComponent<Text> ();
        healthText = moreDetailsGameObject.transform.GetChild (0).GetChild (3).GetChild (1).gameObject.GetComponent<Text> ();
        selectRoleButton = moreDetailsGameObject.transform.GetChild (0).GetChild (4).gameObject.GetComponent<Button> ();

        currentNPC = newNPC;
        setMoreDetails ();
        setSelectRoleButton ();
        setInputField ();

        setHealth (currentNPC.GetComponent<Health> ());
    }

    private void setInputField () {
        nameInputField.onValueChanged.AddListener (delegate {
            setNewInputName (nameInputField.text);
        });
    }

    private void setNewInputName (string text) {
        if (text != null) {
            currentNPC.name = text;
            currentNPC.transform.GetChild (3).GetComponent<TextMesh> ().text = text;
        }
    }

    private void setMoreDetails () {
        this.transform.GetChild (0).GetComponent<statWords> ().setNPC (currentNPC);
        nameInputField.text = currentNPC.name;
        currentJobText.text = currentNPC.GetComponent<collect> ().getFindingType ();
    }

    private void setSelectRoleButton () {
        selectRoleButton.gameObject.GetComponent<Button> ().onClick.AddListener (() => buttonClicked ());
    }

    private void buttonClicked () {
        selectRoleGameObject.SetActive (true);
        selectRoleGameObject.GetComponent<GenerateRoleSelector> ().setCurrentNPC (currentNPC);
        foreach (Transform child in selectRoleGameObject.transform.GetChild(0)) {
            child.gameObject.GetComponent<RoleButtonScript> ().setNPC (currentNPC);
            child.gameObject.GetComponent<StateSwitch> ().setNPC (currentNPC);
        }
    }

    public void setRole () {
        currentJobText.text = currentNPC.GetComponent<collect> ().getFindingType ();
    }

    public void setRole (string role) {
        currentJobText.text = role;
    }

    public void publish () {
        if (npcHealth != null)
            updateHealth ();
    }

    public void setHealth (Health h) {
        if (h != null) {
            npcHealth = h;
            h.addSubscriber (this);
        }
    }

    private void updateHealth () {
        float fractionHealth = npcHealth.getHealth () / (float)npcHealth.getMaxHealth ();
        healthText.text = (System.Math.Round (fractionHealth * 100, 0)).ToString () + "%";
    }
}
