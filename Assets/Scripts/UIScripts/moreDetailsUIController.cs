using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moreDetailsUIController : MonoBehaviour {

    private GameObject currentNPC;

    [SerializeField] private GameObject moreDetailsGameObject;
    [SerializeField] private GameObject selectRoleGameObject;

    [SerializeField] private Text nameText;
    [SerializeField] private Text currentJobText;
    [SerializeField] private Text happynessText;

    [SerializeField] private Button selectRoleButton;

    [SerializeField] private Text stat1;
    [SerializeField] private Text stat2;
    [SerializeField] private Text stat3;
    [SerializeField] private Text stat4;

    public void setNPC (GameObject newNPC) {
        moreDetailsGameObject = this.gameObject;
        selectRoleGameObject = moreDetailsGameObject.transform.parent.GetChild (2).gameObject;
        nameText = moreDetailsGameObject.transform.GetChild (0).GetChild (1).GetChild (0).gameObject.GetComponent<Text> ();
        currentJobText = moreDetailsGameObject.transform.GetChild (0).GetChild (2).GetChild (1).gameObject.GetComponent<Text> ();
        happynessText = moreDetailsGameObject.transform.GetChild (0).GetChild (3).GetChild (1).gameObject.GetComponent<Text> ();
        selectRoleButton = moreDetailsGameObject.transform.GetChild (0).GetChild (4).gameObject.GetComponent<Button> ();

        currentNPC = newNPC;
        setMoreDetails ();
        setSelectRoleButton ();
    }

    private void setMoreDetails () {
        // TODO: get stats of NPC to set stats text.
        nameText.text = currentNPC.name;
        currentJobText.text = currentNPC.GetComponent<collect> ().getFindingType();
    }

    private void setSelectRoleButton () {
        selectRoleButton.gameObject.GetComponent<Button> ().onClick.AddListener (() => buttonClicked ());
    }

    private void buttonClicked () {
        selectRoleGameObject.SetActive (true);
        selectRoleGameObject.GetComponent<GenerateRoleSelector> ().setCurrentNPC (currentNPC);
    }

    public void setRole () {
        currentJobText.text = currentNPC.GetComponent<collect> ().getFindingType ();
    }
}
