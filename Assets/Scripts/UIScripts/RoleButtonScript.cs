using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RoleButtonScript : MonoBehaviour {

    private GameObject currentNPC;

    [SerializeField] private Text buttonText;
    private ResourceTypes type;

    private GameObject moreDetails;

    void Start () {
        moreDetails = GameObject.Find ("npcManagerMoreDetailsScrollView");
    }

    public void setNPC (GameObject aNPC) {
        currentNPC = aNPC;
    }

    public void setButton (GameObject aNPC, ResourceTypes theType) {
        currentNPC = aNPC;
        type = theType;
        setListener ();
        setName ();
    }

    private void setName () {
        buttonText.text = type.ToString ();
    }

    private void setListener () {
        this.gameObject.GetComponent<Button> ().onClick.AddListener (() => button_Click ());
    }

    private void button_Click () {
        StateSwitch.setFollow(false, currentNPC);
        StateSwitch.setGuard(false, currentNPC);

        currentNPC.GetComponent<collect>().enabled = true;
        currentNPC.GetComponent<collect> ().startCollecting(type);
        this.transform.parent.parent.gameObject.SetActive (false);
        moreDetails.GetComponent<moreDetailsUIController> ().setRole ();
    }

}
