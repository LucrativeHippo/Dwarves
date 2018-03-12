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
        currentNPC.GetComponent<collect> ().findingType = type;
        this.transform.parent.parent.gameObject.SetActive (false);
        moreDetails.GetComponent<moreDetailsUIController> ().setRole ();
    }

}
